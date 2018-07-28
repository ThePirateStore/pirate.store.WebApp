using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pirate.store.DataAccess.DataContext;
using pirate.store.Domain.Entities;

namespace pirate.store.WebApp.Controllers
{
    public class ItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {
            ViewBag.Message = "This area is only for admin users";

            return View();
        }

        // GET: Items
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.Catalog);
            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Search()
        {
            var items = db.Items.Include(i => i.Catalog);
            return View(await items.ToListAsync());
        }

        // GET: Items/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Author,Company,Year,Rate,Quality,Version,UniqueCode,MegaLink,CoffeeLink,ImageLink,IsActive,FileFormat,FileSize,CategoryId,SubcategoryId,CreatedDate,ModifiedDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.CreatedDate = DateTime.Now;
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            //ViewBag.SubcategoryId = new SelectList(db.Subcategories, "Id", "Name", item.SubcategoryId);
            return View(item);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            //ViewBag.SubcategoryId = new SelectList(db.Subcategories, "Id", "Name", item.SubcategoryId);
            return View(category);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            //ViewBag.SubcategoryId = new SelectList(db.Subcategories, "Id", "Name", item.SubcategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Author,Company,Year,Rate,Quality,Version,UniqueCode,MegaLink,CoffeeLink,ImageLink,IsActive,FileFormat,FileSize,CategoryId,SubcategoryId,CreatedDate,ModifiedDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ModifiedDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", item.CategoryId);
            //ViewBag.SubcategoryId = new SelectList(db.Subcategories, "Id", "Name", item.SubcategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
