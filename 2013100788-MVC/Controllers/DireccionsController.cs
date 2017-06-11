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
    public class DireccionsController : Controller
    {
        // private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public DireccionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Direccions
        public ActionResult Index()
        {
            var direccions = _UnityOfWork.Direccions.GetEntity().Include(d => d.Ubigeo);
            return View(direccions.ToList());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc");
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Ubigeos.GetEntity(), "UbigeoId", "desc");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirId,desc,UbigeoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Direccions.Add(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", direccion.DirId);
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Ubigeos.GetEntity(), "UbigeoId", "desc", direccion.DirId);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", direccion.DirId);
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Ubigeos.GetEntity(), "UbigeoId", "desc", direccion.DirId);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirId,desc,UbigeoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", direccion.DirId);
            ViewBag.UbigeoId = new SelectList(_UnityOfWork.Ubigeos.GetEntity(), "UbigeoId", "desc", direccion.DirId);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            _UnityOfWork.Direccions.Delete(direccion);
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
