using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2013100788_ENT.Entities;
using _2013100788_PER;
using _2013100788_ENT.IRepositories;
using _2013100788_ENT.EntitiesDTO;
using AutoMapper;

namespace _2013100788_WebAPI.Controllers
{
    public class AdministradorEquipoesApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public AdministradorEquipoesApiController()
        {

        }
        public AdministradorEquipoesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/AdministradorEquipoesApi
        //public IQueryable<AdministradorEquipo> GetAdministradorEquipos()
        //{
        //    return db.AdministradorEquipos;
        // }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var administradorEquipo = _UnityOfWork.AdministradorEquipos.GetAll();
            if (administradorEquipo == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var administradorEquipoDTO = new List<AdministradorEquipoDTO>();
            foreach (var admi in administradorEquipo)
                administradorEquipoDTO.Add(Mapper.Map<AdministradorEquipo, AdministradorEquipoDTO>(admi));
            return Ok(administradorEquipoDTO);
        }

        // GET: api/AdministradorEquipoesApi/5
        //[ResponseType(typeof(AdministradorEquipo))]
       // public IHttpActionResult GetAdministradorEquipo(int id)
      //  {
          //  AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
         //   if (administradorEquipo == null)
       //     {
        //        return NotFound();
        //    }

       //     return Ok(administradorEquipo);
        //}

        //Get Api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var administradorEquipo = _UnityOfWork.AdministradorEquipos.Get(id);
            if (administradorEquipo == null)
                return NotFound();
            return Ok(Mapper.Map<AdministradorEquipo, AdministradorEquipoDTO>(administradorEquipo));
        }


        // PUT: api/AdministradorEquipoesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAdministradorEquipo(int id, AdministradorEquipo administradorEquipo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != administradorEquipo.AdmiEquipId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(administradorEquipo).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdministradorEquipoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}
        [HttpPut]
        public IHttpActionResult Update(int id, AdministradorEquipoDTO administradorEquipoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiEquiPer = _UnityOfWork.AdministradorEquipos.Get(id);
            if (admiEquiPer == null)
                return NotFound();
            Mapper.Map<AdministradorEquipoDTO, AdministradorEquipo>(administradorEquipoDTO, admiEquiPer);
            _UnityOfWork.SaveChanges();
            return Ok(administradorEquipoDTO);
        }

        // POST: api/AdministradorEquipoesApi
        //[ResponseType(typeof(AdministradorEquipo))]
        //public IHttpActionResult PostAdministradorEquipo(AdministradorEquipo administradorEquipo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.AdministradorEquipos.Add(administradorEquipo);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = administradorEquipo.AdmiEquipId }, administradorEquipo);
        //}
        [HttpPost]
        public IHttpActionResult Create(AdministradorEquipoDTO admiEquiDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiEqui = Mapper.Map<AdministradorEquipoDTO, AdministradorEquipo>(admiEquiDTO);
            _UnityOfWork.AdministradorEquipos.Add(admiEqui);
            _UnityOfWork.SaveChanges();
            admiEquiDTO.AdmiEquipId = admiEqui.AdmiEquipId;
            return Created(new Uri(Request.RequestUri + "/" + admiEqui.AdmiEquipId), admiEquiDTO);
        }

        // DELETE: api/AdministradorEquipoesApi/5
        //[ResponseType(typeof(AdministradorEquipo))]
        //public IHttpActionResult DeleteAdministradorEquipo(int id)
        //{
        //    AdministradorEquipo administradorEquipo = db.AdministradorEquipos.Find(id);
        //    if (administradorEquipo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.AdministradorEquipos.Remove(administradorEquipo);
        //    db.SaveChanges();

        //    return Ok(administradorEquipo);
        //}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiEquiInDataBase = _UnityOfWork.AdministradorEquipos.Get(id);
            if (admiEquiInDataBase == null)
                return NotFound();
            _UnityOfWork.AdministradorEquipos.Delete(admiEquiInDataBase);
            _UnityOfWork.SaveChanges();
            return Ok();
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