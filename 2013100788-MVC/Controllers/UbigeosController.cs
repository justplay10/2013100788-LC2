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
    public class UbigeosController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public UbigeosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Ubigeos
        public ActionResult Index()
        {
            //var ubigeos = db.Ubigeos.Include(u => u.Direccions);
            return View(_UnityOfWork.Ubigeos.GetAll());
        }

        // GET: Ubigeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc");
            return View();
        }

        // POST: Ubigeos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UbigeoId,desc,Departamento,Provincia,Distrito")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Ubigeos.Add(ubigeo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc");
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc");
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UbigeoId,desc,Departamento,Provincia,Distrito")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(ubigeo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc");
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ubigeo ubigeo = _UnityOfWork.Ubigeos.Get(id);
            _UnityOfWork.Ubigeos.Delete(ubigeo);
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
