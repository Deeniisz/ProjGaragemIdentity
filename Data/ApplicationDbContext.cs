using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoGaragemIdentity.Models;

namespace ProjetoGaragemIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoGaragemIdentity.Models.Carro> Carro { get; set; }
        public DbSet<ProjetoGaragemIdentity.Models.Cliente> Cliente { get; set; }
        public DbSet<ProjetoGaragemIdentity.Models.Funcionario> Funcionario { get; set; }
        public DbSet<ProjetoGaragemIdentity.Models.TestDrive> TestDrive { get; set; }
        public DbSet<ProjetoGaragemIdentity.Models.Venda> Venda { get; set; }
    }
}