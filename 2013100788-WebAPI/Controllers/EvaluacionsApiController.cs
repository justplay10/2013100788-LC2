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
    public class EvaluacionsApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public EvaluacionsApiController()
        {

        }
        public EvaluacionsApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/Evaluacions
        [HttpGet]
        public IHttpActionResult Get()
        {
            var eva = _UnityOfWork.Evaluacions.GetAll();
            if (eva == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var evaDto = new List<EvaluacionDTO>();
            foreach (var evan in eva)
                evaDto.Add(Mapper.Map<Evaluacion, EvaluacionDTO>(evan));
            return Ok(evaDto);
        }

        // GET: api/Evaluacions/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var eva = _UnityOfWork.Evaluacions.Get(id);
            if (eva == null)
                return NotFound();
            return Ok(Mapper.Map<Evaluacion, EvaluacionDTO>(eva));
        }

        // PUT: api/Evaluacions/5
        [HttpPut]
        public IHttpActionResult Update(int id, EvaluacionDTO evaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var evaPer = _UnityOfWork.Evaluacions.Get(id);
            if (evaPer == null)
                return NotFound();
            Mapper.Map<EvaluacionDTO, Evaluacion>(evaDto, evaPer);
            _UnityOfWork.SaveChanges();
            return Ok(evaDto);
        }
        // POST: api/Evaluacions
        [HttpPost]
        public IHttpActionResult Create(EvaluacionDTO evaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var eva = Mapper.Map<EvaluacionDTO, Evaluacion>(evaDto);
            _UnityOfWork.Evaluacions.Add(eva);
            _UnityOfWork.SaveChanges();
            evaDto.EvalId = eva.EvalId;
            return Created(new Uri(Request.RequestUri + "/" + eva.EvalId), evaDto);
        }

        // DELETE: api/Evaluacions/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var evaInData = _UnityOfWork.Evaluacions.Get(id);
            if (evaInData == null)
                return NotFound();
            _UnityOfWork.Evaluacions.Delete(evaInData);
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