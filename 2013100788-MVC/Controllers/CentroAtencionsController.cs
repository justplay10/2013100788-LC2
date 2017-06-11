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
using _2013100788_ENT.IRepositories;

namespace _2013100788_MVC.Controllers
{
    public class CentroAtencionsController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public CentroAtencionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: CentroAtencions
        public ActionResult Index()
        {
            var centroAtencions = _UnityOfWork.CentroAtencions.GetEntity().Include(c => c.Direccion);
            return View(centroAtencions.ToList());
        }

        // GET: CentroAtencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Create
        public ActionResult Create()
        {
            ViewBag.DirId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc");
            return View();
        }

        // POST: CentroAtencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenAteId,desc,DirId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CentroAtencions.Add(centroAtencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc", centroAtencion.DirId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc", centroAtencion.DirId);
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenAteId,desc,DirId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(centroAtencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirId = new SelectList(_UnityOfWork.Direccions.GetEntity(), "DirId", "desc", centroAtencion.DirId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            _UnityOfWork.CentroAtencions.Delete(centroAtencion);
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
