﻿
using EntityModelFundabien.entities;
using EntityModelFundabien.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrokerServices.common
{
    public class dbContext : DbContext
    {
        //public dbContext(DbContextOptions<dbContext> options)
        //    : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConn = "Server = 70.37.80.92; port = 5432; Database = fundabien; User Id = postgres; Password = Fundabien@2019; Pooling = true; MinPoolSize = 1; MaxPoolSize = 20; ";
            optionsBuilder.UseNpgsql(stringConn);
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Correo> Correos { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PersonaEncargada> PersonasEncargadas { get; set; }
        public DbSet<RegistroMedico> RegistrosMedicos { get; set; }
        public DbSet<RegistroMedicoDiagnostico> RegistrosMedicosDiagnostico { get; set; }

        //to seeds
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.paisesSeed();
            modelBuilder.seedDepartamentos();
            //modelBuilder.seddMunicipios();
        }
    }
}

    