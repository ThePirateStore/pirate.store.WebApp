using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PS_WebApp.Models;

namespace PS_WebApp.Controllers
{
    public class CostumersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Costumers
        public async Task<ActionResult> Index()
        {
            var costumers = db.Costumers.Include(c => c.MembershipType);
            return View(await costumers.ToListAsync());
        }

        // GET: Costumers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = await db.Costumers.FindAsync(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // GET: Costumers/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name");
            return View();
        }

        // POST: Costumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,IsSubscribedToNewsletter,MembershipTypeId")] Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                db.Costumers.Add(costumer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", costumer.MembershipTypeId);
            return View(costumer);
        }

        // GET: Costumers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = await db.Costumers.FindAsync(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", costumer.MembershipTypeId);
            return View(costumer);
        }

        // POST: Costumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,IsSubscribedToNewsletter,MembershipTypeId,CreatedDate")] Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costumer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "Id", "Name", costumer.MembershipTypeId);
            return View(costumer);
        }

        // GET: Costumers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Costumer costumer = await db.Costumers.FindAsync(id);
            if (costumer == null)
            {
                return HttpNotFound();
            }
            return View(costumer);
        }

        // POST: Costumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Costumer costumer = await db.Costumers.FindAsync(id);
            db.Costumers.Remove(costumer);
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
