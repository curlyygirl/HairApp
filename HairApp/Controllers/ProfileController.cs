using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HairApp.Models;
using System.Security.Cryptography;

namespace HairApp.Controllers
{
    public class ProfileController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if(_user == null)
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if(check != null)
                {
                    ViewBag.error = "Email already exists";
                    return View(); 
                }
                
                _user.Password = GetMD5(_user.Password);
                _db.Configuration.ValidateOnSaveEnabled = false;
                _db.Users.Add(_user);
                _db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().idUser;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult ChangePassword()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string password, string confirmPassword)
        {
            if (Session["idUser"] == null)
                return RedirectToAction("Login");
            var idUser = Int32.Parse(Session["idUser"].ToString());

            var _user = _db.Users.Find(idUser);


            if (!password.Equals(confirmPassword))
                return RedirectToAction("ChangePassword");
            _user.Password = GetMD5(password);

            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}