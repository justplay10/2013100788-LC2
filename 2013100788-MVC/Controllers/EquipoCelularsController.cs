using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2013100788_ENT.Entities;
using _2013100788_PER;
using _2013100788_PER.Repositories;
using _2013100788_ENT.IRepositories;

namespace _2013100788_MVC.Controllers
{
    public class EquipoCelularsController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();

        private readonly IUnityOfWork _UnityOfWork;
        public EquipoCelularsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: EquipoCelulars
        public ActionResult Index()
        {
            //var equipoCelulars = db.EquipoCelulars.Include(e => e.Evaluacions);
            return View(_UnityOfWork.EquipoCelulars.GetAll());
        }

        // GET: EquipoCelulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Create
        public ActionResult Create()
        {
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc");
            return View();
        }

        // POST: EquipoCelulars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipCelId,descrip")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                // db.EquipoCelulars.Add(equipoCelular);
                _UnityOfWork.EquipoCelulars.Add(equipoCelular);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipCelId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", equipoCelular.EquipCelId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", equipoCelular.EquipCelId);
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipCelId,descrip")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(equipoCelular).State = EntityState.Modified;
                _UnityOfWork.StateModified(equipoCelular);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", equipoCelular.EquipCelId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoCelular equipoCelular = _UnityOfWork.EquipoCelulars.Get(id);
            //db.EquipoCelulars.Remove(equipoCelular);
            _UnityOfWork.EquipoCelulars.Delete(equipoCelular);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
