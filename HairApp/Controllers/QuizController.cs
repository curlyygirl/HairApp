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
    public class QuizController : Controller
    {
        private DB_Entities db = new DB_Entities();

        // GET: Quiz
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var idUser = (int)Session["idUser"];

            var quiz = db.Quizzes.Where(q => q.idUser == idUser).FirstOrDefault();
            if (quiz == null)
                return RedirectToAction("Create");
            else
                return RedirectToAction("Details", new { id = quiz.id });
            
                
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");

            return View();
        }

        // POST: Quiz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idUser,Type,Porosity,Thickness,Density,Dyed,Destroyed,Length")] Quiz quiz)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                quiz.idUser = (int)Session["idUser"];
                db.Quizzes.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        // GET: QuizProba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: QuizProba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idUser,Type,Porosity,Thickness,Density,Dyed,Destroyed,Length")] Quiz quiz)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quiz quiz = db.Quizzes.Find(id);
            db.Quizzes.Remove(quiz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
