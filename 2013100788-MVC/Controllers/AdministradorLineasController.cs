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
    public class AdministradorLineasController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;

        public AdministradorLineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: AdministradorLineas
        public ActionResult Index()
        {
            var administradorLineas = _UnityOfWork.AdministradorLineas.GetEntity().Include(a => a.LineaTelefonica);
            return View(administradorLineas.ToList());
        }

        // GET: AdministradorLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Create
        public ActionResult Create()
        {
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc");
            return View();
        }

        // POST: AdministradorLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmiLinId,desc,LinTelfId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                //db.AdministradorLineas.Add(administradorLinea);
                _UnityOfWork.AdministradorLineas.Add(administradorLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", administradorLinea.LinTelfId);
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", administradorLinea.LinTelfId);
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmiLinId,desc,LinTelfId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(administradorLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", administradorLinea.LinTelfId);
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorLinea administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            _UnityOfWork.AdministradorLineas.Delete(administradorLinea);
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
