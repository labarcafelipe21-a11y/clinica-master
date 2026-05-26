using clinica.Models;
using Microsoft.EntityFrameworkCore;

namespace clinica.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
            : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}