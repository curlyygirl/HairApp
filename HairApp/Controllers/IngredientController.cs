using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HairApp.Models;

namespace HairApp.Controllers
{
    public class IngredientController : Controller
    {
        private DB_Entities db = new DB_Entities();

        // GET: Ingredient
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: Ingredient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login", "Profile");

            return View();
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Type")] Ingredient ingredient)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login", "Profile");

            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        public ActionResult Search(string name)
        {
            if (String.IsNullOrEmpty(name))
                return RedirectToAction("Index");

            var ingredient = db.Ingredients.Where(i => i.Name.Equals(name)).FirstOrDefault();

            if(ingredient == null)
            {
                ViewBag.error = "Składnika nie ma w bazie";
                return View("Index", db.Ingredients.ToList());
            }

            return RedirectToAction("Details", new { id = ingredient.id });
        }

    }
}
