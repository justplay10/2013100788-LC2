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
    public class AdministradorLineassApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public AdministradorLineassApiController() 
        {

        }
        public AdministradorLineassApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/AdministradorLineassApi
        //public IQueryable<AdministradorLineas> GetAdministradorLineas()
        //{
        //    return db.AdministradorLineas;
        // }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var administradorLinea = _UnityOfWork.AdministradorLineas.GetAll();
            if (administradorLinea == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var administradorLineaDTO = new List<AdministradorLineaDTO>();
            foreach (var admi in administradorLinea)
                administradorLineaDTO.Add(Mapper.Map<AdministradorLinea, AdministradorLineaDTO>(admi));
            return Ok(administradorLineaDTO);
        }


        //Get Api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var administradorLinea = _UnityOfWork.AdministradorLineas.Get(id);
            if (administradorLinea == null)
                return NotFound();
            return Ok(Mapper.Map<AdministradorLinea, AdministradorLineaDTO>(administradorLinea));
        }


        // PUT: api/AdministradorLineassApi/5

        [HttpPut]
        public IHttpActionResult Update(int id, AdministradorLineaDTO administradorLineaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiLinPer = _UnityOfWork.AdministradorLineas.Get(id);
            if (admiLinPer == null)
                return NotFound();
            Mapper.Map<AdministradorLineaDTO, AdministradorLinea>(administradorLineaDTO, admiLinPer);
            _UnityOfWork.SaveChanges();
            return Ok(administradorLineaDTO);
        }

        // POST: api/AdministradorLineassApi

        [HttpPost]
        public IHttpActionResult Create(AdministradorLineaDTO admiLinDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiLin = Mapper.Map<AdministradorLineaDTO, AdministradorLinea>(admiLinDTO);
            _UnityOfWork.AdministradorLineas.Add(admiLin);
            _UnityOfWork.SaveChanges();
            admiLinDTO.AdmiLinId = admiLin.AdmiLinId;
            return Created(new Uri(Request.RequestUri + "/" + admiLin.AdmiLinId), admiLinDTO);
        }

        // DELETE: api/AdministradorLineassApi/5

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var admiLinInDataBase = _UnityOfWork.AdministradorLineas.Get(id);
            if (admiLinInDataBase == null)
                return NotFound();
            _UnityOfWork.AdministradorLineas.Delete(admiLinInDataBase);
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