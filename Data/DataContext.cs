using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcompanhamentoPaciente.Models;
using Microsoft.EntityFrameworkCore;

namespace AcompanhamentoPaciente.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Acompanhamento> Acompanhamento {get; set;}
        public DbSet<Cargo> Cargo {get; set;}
        public DbSet<Exame> Exame {get; set;}
        public DbSet<Paciente> Paciente {get; set;}
        public DbSet<Profissional> Profissional {get; set;}


        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}