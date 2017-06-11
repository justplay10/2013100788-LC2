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
    public class EstadoEvaluacionsApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public EstadoEvaluacionsApiController()
        {
        }
        public EstadoEvaluacionsApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/EstadoEvaluacions
        [HttpGet]
        public IHttpActionResult Get()
        {
            var est = _UnityOfWork.EstadoEvaluacions.GetAll();
            if (est == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var estDto = new List<EstadoEvaluacionDTO>();
            foreach (var esta in est)
                estDto.Add(Mapper.Map<EstadoEvaluacion, EstadoEvaluacionDTO>(esta));
            return Ok(estDto);
        }

        // GET: api/EstadoEvaluacions/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var est = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (est == null)
                return NotFound();
            return Ok(Mapper.Map<EstadoEvaluacion, EstadoEvaluacionDTO>(est));
        }

        // PUT: api/EstadoEvaluacions/5
        [HttpPut]
        public IHttpActionResult Update(int id, EstadoEvaluacionDTO estDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var estPer = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estPer == null)
                return NotFound();

            Mapper.Map<EstadoEvaluacionDTO, EstadoEvaluacion>(estDto, estPer);

            _UnityOfWork.SaveChanges();
            return Ok(estDto);
        }

        // POST: api/EstadoEvaluacions
        [HttpPost]
        public IHttpActionResult Create(EstadoEvaluacionDTO estDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var est = Mapper.Map<EstadoEvaluacionDTO, EstadoEvaluacion>(estDto);
            _UnityOfWork.EstadoEvaluacions.Add(est);
            _UnityOfWork.SaveChanges();
            estDto.EstEvaId = est.EstEvaId;
            return Created(new Uri(Request.RequestUri + "/" + est.EstEvaId), estDto);
        }


        // DELETE: api/EstadoEvaluacions/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var estIndata = _UnityOfWork.EstadoEvaluacions.Get(id);
            if (estIndata == null)
                return NotFound();
            _UnityOfWork.EstadoEvaluacions.Delete(estIndata);
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