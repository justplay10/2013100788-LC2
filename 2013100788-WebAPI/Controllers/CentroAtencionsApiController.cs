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
    public class CentroAtencionsApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public CentroAtencionsApiController()
        {

        }
        public CentroAtencionsApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/CentroAtencions
        [HttpGet]
        public IHttpActionResult Get()
        {
            var centAte = _UnityOfWork.CentroAtencions.GetAll();
            if (centAte == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var centAteDTO = new List<CentroAtencionDTO>();
            foreach (var cent in centAte)
                centAteDTO.Add(Mapper.Map<CentroAtencion, CentroAtencionDTO>(cent));
            return Ok(centAteDTO);
        }

        // GET: api/CentroAtencions/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cent = _UnityOfWork.CentroAtencions.Get(id);
            if (cent == null)
                return NotFound();
            return Ok(Mapper.Map<CentroAtencion, CentroAtencionDTO>(cent));
        }

        // PUT: api/CentroAtencions/5
        [HttpPut]
        public IHttpActionResult Update(int id, CentroAtencionDTO centDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var centPer = _UnityOfWork.CentroAtencions.Get(id);
            if (centPer == null)
                return NotFound();
            Mapper.Map<CentroAtencionDTO, CentroAtencion>(centDto, centPer);
            _UnityOfWork.SaveChanges();
            return Ok(centDto);
        }

        // POST: api/CentroAtencions
        [HttpPost]
        public IHttpActionResult Create(CentroAtencionDTO centDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cent = Mapper.Map<CentroAtencionDTO, CentroAtencion>(centDto);
            _UnityOfWork.CentroAtencions.Add(cent);
            _UnityOfWork.SaveChanges();
            centDto.CenAteId = cent.CenAteId;
            return Created(new Uri(Request.RequestUri + "/" + cent.CenAteId), centDto);
        }

        // DELETE: api/CentroAtencions/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var centInDataBase = _UnityOfWork.CentroAtencions.Get(id);
            if (centInDataBase == null)
                return NotFound();
            _UnityOfWork.CentroAtencions.Delete(centInDataBase);
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