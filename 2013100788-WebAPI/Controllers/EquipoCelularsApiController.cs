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
    public class EquipoCelularsApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public EquipoCelularsApiController()
        {

        }
        public EquipoCelularsApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/EquipoCelulars
        [HttpGet]
        public IHttpActionResult Get()
        {
            var equiCel = _UnityOfWork.EquipoCelulars.GetAll();
            if (equiCel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var equiCelDto = new List<EquipoCelularDTO>();
            foreach (var equi in equiCel)
                equiCelDto.Add(Mapper.Map<EquipoCelular, EquipoCelularDTO>(equi));
            return Ok(equiCelDto);
        }

        // GET: api/EquipoCelulars/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var equiCel = _UnityOfWork.EquipoCelulars.Get(id);
            if (equiCel == null)
                return NotFound();
            return Ok(Mapper.Map<EquipoCelular, EquipoCelularDTO>(equiCel));
        }

        // PUT: api/EquipoCelulars/5
        [HttpPut]
        public IHttpActionResult Update(int id, EquipoCelularDTO equiDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var equiPer = _UnityOfWork.EquipoCelulars.Get(id);
            if (equiPer == null)
                return NotFound();
            Mapper.Map<EquipoCelularDTO, EquipoCelular>(equiDto, equiPer);
            _UnityOfWork.SaveChanges();
            return Ok(equiDto);
        }

        // POST: api/EquipoCelulars
        [HttpPost]
        public IHttpActionResult Create(EquipoCelularDTO equiDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var equi = Mapper.Map<EquipoCelularDTO, EquipoCelular>(equiDto);
            _UnityOfWork.EquipoCelulars.Add(equi);
            _UnityOfWork.SaveChanges();
            equiDto.EquipCelId = equi.EquipCelId;
            return Created(new Uri(Request.RequestUri + "/" + equi.EquipCelId), equiDto);
        }

        // DELETE: api/EquipoCelulars/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var equiInDataBase = _UnityOfWork.EquipoCelulars.Get(id);
            if (equiInDataBase == null)
                return NotFound();
            _UnityOfWork.EquipoCelulars.Delete(equiInDataBase);
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