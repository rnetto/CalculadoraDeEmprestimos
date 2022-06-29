using CalculadoraDeEmprestimos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraDeEmprestimos.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DadosUsuario> DadosUsuario { get; set; }
        public DbSet<SimulacaoUsuario> SimulacaoUsuario { get; set; }
       
    }
}
