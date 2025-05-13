using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ControleFinanceiro.Models

{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TransacaoModel> Transacoes { get; set; }
    }
}
