﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModelFundabien.entities
{
    public class CicloDeRehabilitacion
    {
        [Key]
        public Int64 idcicloRehabilitacion { get; set; }
        public Int64 idPaciente { get; set; }
        public string dignostico { get; set; }
        public string origen { get; set; }
        public string cie_10 { get; set; }
        public string otros { get; set; }
        public DateTime fecha { get; set; }
        public string funcionEstrucCorporales { get; set; }
        public string actividad { get; set; }
        public string participacion { get; set; }
        public string factoresAmbientales { get; set; }
        public string factoresPersonales { get; set; }
        public Paciente paciente { get; set; }
        public List<DetalleCicloDeRehabilitacion> detalleCicloRehabilitacion { get; set; }
    }
}
