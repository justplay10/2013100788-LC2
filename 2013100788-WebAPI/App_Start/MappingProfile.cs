using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using _2013100788_ENT.Entities;
using _2013100788_ENT.EntitiesDTO;

namespace _2013100788_WebAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdministradorEquipo, AdministradorEquipoDTO>();
            CreateMap<AdministradorEquipoDTO, AdministradorEquipo>();

            CreateMap<AdministradorLinea, AdministradorLineaDTO>();
            CreateMap<AdministradorLineaDTO, AdministradorLinea>();

            CreateMap<CentroAtencion, CentroAtencionDTO>();
            CreateMap<CentroAtencionDTO, CentroAtencion>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();

            CreateMap<Direccion, DireccionDTO>();
            CreateMap<DireccionDTO, Direccion>();

            CreateMap<EquipoCelular, EquipoCelularDTO>();
            CreateMap<EquipoCelularDTO, EquipoCelular>();

            CreateMap<EstadoEvaluacion, EstadoEvaluacionDTO>();
            CreateMap<EstadoEvaluacionDTO, EstadoEvaluacion>();

            CreateMap<Evaluacion, EvaluacionDTO>();
            CreateMap<EvaluacionDTO, Evaluacion>();

            CreateMap<LineaTelefonica, LineaTelefonicaDTO>();
            CreateMap<LineaTelefonicaDTO, LineaTelefonica>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<Ubigeo, UbigeoDTO>();
            CreateMap<UbigeoDTO, Ubigeo>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();
        }
    }
}