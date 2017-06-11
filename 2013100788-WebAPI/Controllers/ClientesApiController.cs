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
    public class ClientesApiController : ApiController
    {
        //private LineasNuevasContext db = new LineasNuevasContext();
        private readonly IUnityOfWork _UnityOfWork;
        public ClientesApiController()
        {

        }
        public ClientesApiController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: api/Clientes
        [HttpGet]
        public IHttpActionResult Get()
        {
            var cli = _UnityOfWork.Clientes.GetAll();
            if (cli == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var cliDto = new List<ClienteDTO>();
            foreach (var client in cli)
                cliDto.Add(Mapper.Map<Cliente, ClienteDTO>(client));
            return Ok(cliDto);
        }

        // GET: api/Clientes/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cli = _UnityOfWork.Clientes.Get(id);
            if (cli == null)
                return NotFound();
            return Ok(Mapper.Map<Cliente, ClienteDTO>(cli));
        }

        // PUT: api/Clientes/5
        [HttpPut]
        public IHttpActionResult Update(int id, ClienteDTO cliDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cliPer = _UnityOfWork.Clientes.Get(id);
            if (cliPer == null)
                return NotFound();
            Mapper.Map<ClienteDTO, Cliente>(cliDto, cliPer);
            _UnityOfWork.SaveChanges();
            return Ok(cliDto);
        }

        // POST: api/Clientes
        [HttpPost]
        public IHttpActionResult Create(ClienteDTO cliDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cli = Mapper.Map<ClienteDTO, Cliente>(cliDto);
            _UnityOfWork.Clientes.Add(cli);
            _UnityOfWork.SaveChanges();
            cliDto.ClienteId = cli.ClienteId;
            return Created(new Uri(Request.RequestUri + "/" + cli.ClienteId), cliDto);
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cliInDataBase = _UnityOfWork.Clientes.Get(id);
            if (cliInDataBase == null)
                return NotFound();
            _UnityOfWork.Clientes.Delete(cliInDataBase);
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