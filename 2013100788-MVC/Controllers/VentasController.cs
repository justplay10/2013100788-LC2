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
    public class VentasController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public VentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Ventas
        public ActionResult Index()
        {
            //var ventas = db.Ventas.Include(v => v.CentroAtencion).Include(v => v.Cliente).Include(v => v.Contrato).Include(v => v.Evaluacion).Include(v => v.LineaTelefonica);
            return View(_UnityOfWork.Ventas.GetAll());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc");
            ViewBag.VentaId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre");
            ViewBag.VentaId = new SelectList(_UnityOfWork.Contratos.GetEntity(), "ContratoId", "desc");
            ViewBag.VentaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc");
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,desc,LinTelfId,EvalId,ClienteId,TipoPago,ContratoId,CenAteId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Ventas.Add(venta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", venta.CenAteId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Contratos.GetEntity(), "ContratoId", "desc", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", venta.VentaId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", venta.LinTelfId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", venta.CenAteId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Contratos.GetEntity(), "ContratoId", "desc", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", venta.VentaId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", venta.LinTelfId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,desc,LinTelfId,EvalId,ClienteId,TipoPago,ContratoId,CenAteId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(venta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CenAteId = new SelectList(_UnityOfWork.CentroAtencions.GetEntity(), "CenAteId", "desc", venta.CenAteId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Clientes.GetEntity(), "ClienteId", "Nombre", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Contratos.GetEntity(), "ContratoId", "desc", venta.VentaId);
            ViewBag.VentaId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", venta.VentaId);
            ViewBag.LinTelfId = new SelectList(_UnityOfWork.LineaTelefonicas.GetEntity(), "LinTelfId", "desc", venta.LinTelfId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = _UnityOfWork.Ventas.Get(id);
            _UnityOfWork.Ventas.Delete(venta);
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
