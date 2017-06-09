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
    public class EstadoEvaluacionsController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public EstadoEvaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: EstadoEvaluacions
        public ActionResult Index()
        {
            //var estadoEvaluacions = db.EstadoEvaluacions.Include(e => e.Evaluacions);
            return View(_UnityOfWork.EstadoEvaluacions.GetAll());
        }

        // GET: EstadoEvaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Create
        public ActionResult Create()
        {
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc");
            return View();
        }

        // POST: EstadoEvaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstEvaId,desc")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.EstadoEvaluacions.Add(estadoEvaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstEvaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", estadoEvaluacion.EstEvaId);
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", estadoEvaluacion.EstEvaId);
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstEvaId,desc")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(estadoEvaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", estadoEvaluacion.EstEvaId);
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoEvaluacion estadoEvaluacion = _UnityOfWork.EstadoEvaluacions.Get(id);
            _UnityOfWork.EstadoEvaluacions.Delete(estadoEvaluacion);
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
