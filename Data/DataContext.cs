using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralizadorExames.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralizadorExames.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Acompanhamento> Acompanhamento {get; set;}
        public DbSet<Cargo> Cargo {get; set;}
        public DbSet<Exame> Exame {get; set;}
        public DbSet<Paciente> Paciente {get; set;}
        public DbSet<Profissional> Profissional {get; set;}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=CentralizadorExames;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}