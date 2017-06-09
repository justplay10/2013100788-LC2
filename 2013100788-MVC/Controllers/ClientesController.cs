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
    public class ClientesController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public ClientesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Clientes
        public ActionResult Index()
        {
            //var clientes = db.Clientes.Include(c => c.Evaluacions).Include(c => c.Ventas);
            return View(_UnityOfWork.Clientes.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _UnityOfWork.Clientes.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc");
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Ventas.GetEntity(), "VentaId", "desc");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nombre")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Clientes.Add(cliente);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", cliente.ClienteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Ventas.GetEntity(), "VentaId", "desc", cliente.ClienteId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _UnityOfWork.Clientes.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", cliente.ClienteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Ventas.GetEntity(), "VentaId", "desc", cliente.ClienteId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nombre")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(cliente);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Evaluacions.GetEntity(), "EvalId", "desc", cliente.ClienteId);
            ViewBag.ClienteId = new SelectList(_UnityOfWork.Ventas.GetEntity(), "VentaId", "desc", cliente.ClienteId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _UnityOfWork.Clientes.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = _UnityOfWork.Clientes.Get(id);
            _UnityOfWork.Clientes.Delete(cliente);
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
