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
    public class AdministradorEquipoesController : Controller
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;

        public AdministradorEquipoesController()
        {

        }
        public AdministradorEquipoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: AdministradorEquipoes
        public ActionResult Index()
        {
            //var unityOfWork = db.AdministradorEquipos.Include(a => a.EquipoCelular);
            //return View(administradorEquipos.ToList());
            return View(_UnityOfWork.AdministradorEquipos.GetAll());
        }

        // GET: AdministradorEquipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
            AdministradorEquipo administradorEquipo = _UnityOfWork.AdministradorEquipos.Get(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Create
        public ActionResult Create()
        {
           ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip");
            return View();
        }

        // POST: AdministradorEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmiEquipId,desc,EquipCelId")] AdministradorEquipo administradorEquipo)
        {
            if (ModelState.IsValid)
            {
                //db.AdministradorEquipos.Add(administradorEquipo);
                _UnityOfWork.AdministradorEquipos.Add(administradorEquipo);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

           ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", administradorEquipo.EquipCelId);
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
            AdministradorEquipo administradorEquipo = _UnityOfWork.AdministradorEquipos.Get(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", administradorEquipo.EquipCelId);
            return View(administradorEquipo);
        }

        // POST: AdministradorEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmiEquipId,desc,EquipCelId")] AdministradorEquipo administradorEquipo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(administradorEquipo).State = EntityState.Modified;
                _UnityOfWork.StateModified(administradorEquipo);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipCelId = new SelectList(_UnityOfWork.EquipoCelulars.GetEntity(), "EquipCelId", "descrip", administradorEquipo.EquipCelId);
            return View(administradorEquipo);
        }

        // GET: AdministradorEquipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
            AdministradorEquipo administradorEquipo = _UnityOfWork.AdministradorEquipos.Get(id);
            if (administradorEquipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorEquipo);
        }

        // POST: AdministradorEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
            AdministradorEquipo administradorEquipo = _UnityOfWork.AdministradorEquipos.Get(id);
            //db.AdministradorEquipos.Remove(administradorEquipo);
            _UnityOfWork.AdministradorEquipos.Delete(administradorEquipo);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
