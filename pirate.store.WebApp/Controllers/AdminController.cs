using pirate.store.DataAccess.DataContext;
using pirate.store.Domain.Entities;
using pirate.store.Domain.Models;
using pirate.store.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace pirate.store.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            IList<Item> itemList = new List<Item>(db.Items);
            IList<Category> cateList = new List<Category>(db.Categories);
            var itemAdmin = new AdminViewModel();
            foreach (var i in itemList)
            {
                itemAdmin.Items.Add(i);
            }

            foreach (var i in cateList)
            {
                itemAdmin.Categories.Add(i);
            }

            return View(itemAdmin);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateItem()
        {
            return View();
        }

        // POST: Admin/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult CreateItem(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
