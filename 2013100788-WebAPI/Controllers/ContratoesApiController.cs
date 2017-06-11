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
    public class ContratoesApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public ContratoesApiController()
        {

        }
        public ContratoesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/Contratoes
        [HttpGet]
        public IHttpActionResult Get()
        {
            var cont = _UnityOfWork.Contratos.GetAll();
            if (cont == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var contDto = new List<ContratoDTO>();
            foreach (var con in cont)
                contDto.Add(Mapper.Map<Contrato, ContratoDTO>(con));
            return Ok(contDto);
        }

        // GET: api/Contratoes/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cont = _UnityOfWork.Contratos.Get(id);
            if (cont == null)
                return NotFound();
            return Ok(Mapper.Map<Contrato, ContratoDTO>(cont));
        }

        // PUT: api/Contratoes/5
        [HttpPut]
        public IHttpActionResult Update(int id, ContratoDTO contDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var contPer = _UnityOfWork.Contratos.Get(id);
            if (contPer == null)
                return NotFound();
            Mapper.Map<ContratoDTO, Contrato>(contDto, contPer);
            _UnityOfWork.SaveChanges();
            return Ok(contDto);
        }
        // POST: api/Contratoes

        [HttpPost]
        public IHttpActionResult Create(ContratoDTO contDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cont = Mapper.Map<ContratoDTO, Contrato>(contDto);
            _UnityOfWork.Contratos.Add(cont);
            _UnityOfWork.SaveChanges();
            contDto.ContratoId = cont.ContratoId;
            return Created(new Uri(Request.RequestUri + "/" + cont.ContratoId), contDto);
        }   

        // DELETE: api/Contratoes/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var contInDataBase = _UnityOfWork.Contratos.Get(id);
            if (contInDataBase == null)
                return NotFound();
            _UnityOfWork.Contratos.Delete(contInDataBase);
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