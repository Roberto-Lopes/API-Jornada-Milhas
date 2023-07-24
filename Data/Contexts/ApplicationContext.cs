using api_alura_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace api_alura_challenge.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opts)
            : base(opts) { }

        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
    }
}
