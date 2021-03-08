using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skill_CodeFirst_Entity.Models.Sınıflar;

namespace Skill_CodeFirst_Entity.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        CONTEXT c = new CONTEXT();
        public ActionResult Index()
        {
          
            var degerler = c.YETENEKLERS.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Yetenekler y)
        {
            c.YETENEKLERS.Add(y);
            c.SaveChanges();
            return View();
        }
        public ActionResult YetenekSil(int id)
        {
            var deger = c.YETENEKLERS.Find(id);
            c.YETENEKLERS.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var deger = c.YETENEKLERS.Find(id);
            return View("YetenekGetir",deger);
        }
        [HttpPost]
        public ActionResult YetenekGetir(Yetenekler y)
        {
            var x = c.YETENEKLERS.Find(y.ID);
            x.ACIKLAMA = y.ACIKLAMA;
            x.DEGER = y.DEGER;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}