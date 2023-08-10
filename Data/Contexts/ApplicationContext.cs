using api_jornada_milhas.Models;
using Microsoft.EntityFrameworkCore;

namespace api_jornada_milhas.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opts)
            : base(opts) { }

        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Destino> Destinos { get; set; }
    }
}
