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
    public class EvaluacionsController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public EvaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Evaluacions
        public ActionResult Index()
        {
            //var evaluacions = db.Evaluacions.Include(e => e.CentroAtencion).Include(e => e.Cliente).Include(e => e.EquipoCelular).Include(e => e.EstadoEvaluacion).Include(e => e.LineaTelefonica).Include(e => e.Trabajador).Include(e => e.Ventas);
            return View(_UnityOfWork.Evaluacions.GetAll());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc");
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre");
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip");
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.EstadoEvaluacions.GetEntity(), "EstEvaId", "desc");
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc");
            ViewBag.TrabaId = new SelectList(_UnityOfWork.Trabajadors.GetEntity(), "TrabaId", "desc");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvalId,desc,EquipCelId,TipoPlan,Plan,LinTelfId,TrabaId,EstEvaId,TipoEvaluacion,ClienteId,CenAteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Evaluacions.Add(evaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", evaluacion.CenAteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", evaluacion.EvalId);
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", evaluacion.EvalId);
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.EstadoEvaluacions.GetEntity(), "EstEvaId", "desc", evaluacion.EvalId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", evaluacion.EvalId);
            ViewBag.TrabaId = new SelectList(_UnityOfWork.Trabajadors.GetEntity(), "TrabaId", "desc", evaluacion.TrabaId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", evaluacion.CenAteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", evaluacion.EvalId);
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", evaluacion.EvalId);
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.EstadoEvaluacions.GetEntity(), "EstEvaId", "desc", evaluacion.EvalId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", evaluacion.EvalId);
            ViewBag.TrabaId = new SelectList(_UnityOfWork.Trabajadors.GetEntity(), "TrabaId", "desc", evaluacion.TrabaId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvalId,desc,EquipCelId,TipoPlan,Plan,LinTelfId,TrabaId,EstEvaId,TipoEvaluacion,ClienteId,CenAteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(evaluacion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", evaluacion.CenAteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", evaluacion.EvalId);
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", evaluacion.EvalId);
            ViewBag.EstEvaId = new SelectList(_UnityOfWork.EstadoEvaluacions.GetEntity(), "EstEvaId", "desc", evaluacion.EvalId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", evaluacion.EvalId);
            ViewBag.TrabaId = new SelectList(_UnityOfWork.Trabajadors.GetEntity(), "TrabaId", "desc", evaluacion.TrabaId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = _UnityOfWork.Evaluacions.Get(id);
            _UnityOfWork.Evaluacions.Delete(evaluacion);
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
