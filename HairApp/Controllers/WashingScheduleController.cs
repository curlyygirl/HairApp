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
    public class WashingScheduleController : Controller
    {
        private DB_Entities db = new DB_Entities();
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Profile");
            }
            var idUser = (int)Session["idUser"];

            var quiz = db.Quizzes.Where(q => q.idUser == idUser).FirstOrDefault();
            if(quiz == null)
            {
                return RedirectToAction("Index", "Quiz");
            }

            var list = CreateSchedule(quiz);

            return View(list);
        }

        private List<Wash> CreateSchedule(Quiz quiz)
        {
            List<Wash> list = new List<Wash>();
            string name;
            Wash wash;

            //wash1
            name = "E-SLS-PEH";
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash2
            switch (quiz.Porosity)
            {
                case "wysokoporowate": name = "E-L-E"; break;
                case "średnioporowate": name = "E-L-E"; break;
                case "niskoporowate": name = "P-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash3
            switch (quiz.Type)
            {
                case "1a": name = "E-L-EH"; break;
                case "1b": name = "E-L-EH"; break;
                case "1c": name = "E-L-EH"; break;
                case "2a": name = "P-L-E"; break;
                case "2b": name = "EH-L-E"; break;
                case "2c": name = "EH-L-E"; break;
                case "3a": name = "E-L-E"; break;
                case "3b": name = "E-L-E"; break;
                case "3c": name = "E-L-E"; break;
                case "4a": name = "E-L-E"; break;
                case "4b": name = "E-L-E"; break;
                case "4c": name = "E-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash4
            switch (quiz.Thickness)
            {
                case "cienkie": name = "PEH-L-E"; break;
                case "normalne": name = "EH-L-E"; break;
                case "grube": name = "E-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash5
            name = "E-SLS-PEH";
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash6
            switch (quiz.Porosity)
            {
                case "wysokoporowate": name = "E-L-E"; break;
                case "średnioporowate": name = "E-L-E"; break;
                case "niskoporowate": name = "P-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash7
            switch (quiz.Type)
            {
                case "1a": name = "E-L-EH"; break;
                case "1b": name = "E-L-EH"; break;
                case "1c": name = "E-L-EH"; break;
                case "2a": name = "P-L-E"; break;
                case "2b": name = "EH-L-E"; break;
                case "2c": name = "EH-L-E"; break;
                case "3a": name = "E-L-E"; break;
                case "3b": name = "E-L-E"; break;
                case "3c": name = "E-L-E"; break;
                case "4a": name = "E-L-E"; break;
                case "4b": name = "E-L-E"; break;
                case "4c": name = "E-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            //wash8
            switch (quiz.Thickness)
            {
                case "cienkie": name = "PEH-L-E"; break;
                case "normalne": name = "EH-L-E"; break;
                case "grube": name = "E-L-E"; break;
                default: break;
            }
            wash = db.Washes.Where(w => w.Name.Equals(name)).FirstOrDefault();
            list.Add(wash);

            return list;
        }
        
    }
}