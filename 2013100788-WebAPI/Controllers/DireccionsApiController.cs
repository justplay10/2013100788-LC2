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
    public class DireccionsApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public DireccionsApiController()
        {

        }
        public DireccionsApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/Direccions
        [HttpGet]
        public IHttpActionResult Get()
        {
            var dir = _UnityOfWork.Direccions.GetAll();
            if (dir == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var dirDto = new List<DireccionDTO>();
            foreach (var dire in dir)
                dirDto.Add(Mapper.Map<Direccion, DireccionDTO>(dire));
            return Ok(dirDto);
        }

        // GET: api/Direccions/5

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var dir = _UnityOfWork.Direccions.Get(id);
            if (dir == null)
                return NotFound();
            return Ok(Mapper.Map<Direccion, DireccionDTO>(dir));
        }

        // PUT: api/Direccions/5
        [HttpPut]
        public IHttpActionResult Update(int id, DireccionDTO dirDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var dirPer = _UnityOfWork.Direccions.Get(id);
            if (dirPer == null)
                return NotFound();
            Mapper.Map<DireccionDTO, Direccion>(dirDto, dirPer);
            _UnityOfWork.SaveChanges();
            return Ok(dirDto);
        }

        // POST: api/Direccions
        [HttpPost]
        public IHttpActionResult Create(DireccionDTO dirDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var dir = Mapper.Map<DireccionDTO, Direccion>(dirDto);
            _UnityOfWork.Direccions.Add(dir);
            _UnityOfWork.SaveChanges();
            dirDto.DirId = dir.DirId;
            return Created(new Uri(Request.RequestUri + "/" + dir.DirId), dirDto);
        }

        // DELETE: api/Direccions/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var dirInDataBase = _UnityOfWork.Direccions.Get(id);
            if (dirInDataBase == null)
                return NotFound();
            _UnityOfWork.Direccions.Delete(dirInDataBase);
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