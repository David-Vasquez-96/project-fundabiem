﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrokerServices.common;
using EntityModelFundabien.entities;
using EntityModelFundabien.Interfaces;
using fundabiemAPI.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fundabiemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : coreControllerFundabiem<PacienteController>
    {
        private readonly IFundabiemCommonLogic<int, int> fundabiem;
        private readonly IMapper mapper;
        private readonly dbContext context;
        public PacienteController(ILogger<PacienteController> logger,
        IFundabiemCommonLogic<int, int> fundabiem, IMapper mapper, dbContext context) : base(logger)
        {
            this.fundabiem = fundabiem;
            this.mapper = mapper;
            this.context = context;
        }

        //obtiene paciente segun id
        [HttpGet("paciente/searchBy/{criterio}/valor/{valor}")]
        public ActionResult<IEnumerable<Paciente>> searchPacienteId(string valor , string criterio)
        {
            logger.LogInformation("Search paciente with valor {0} by user => {1}", valor, getUser());
            var paciente = fundabiem.searchPaciente(valor, criterio);
            if (paciente.Count() == 0)
                return NotFound();
            return Ok(paciente);
        }

        [HttpGet("paciente/searchByHistorialClinico")]
        //obtiene paciente segun su numero de historialClinico
        public ActionResult<IEnumerable<Paciente>> serachByNoHistorialClinico(int NumeroHistoriakClinico)
        {
            logger.LogInformation("Search paciente with Numero historial clinico {0} by user {1}", NumeroHistoriakClinico, getUser());
            var paciente = fundabiem.searchPacienteByHistorialClinico(NumeroHistoriakClinico);
            if (paciente.Count() == 0)
                return NotFound();
            return Ok(paciente);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Paciente>> getAll()
        {
            logger.LogInformation("Get all pacientes by user => {0}", getUser());
            var pacientes = fundabiem.getAllPacientes();
            if (pacientes.Count() == 0) { return BadRequest("No se encontraron pacientes"); }
            return Ok(pacientes);
        }

    }
}