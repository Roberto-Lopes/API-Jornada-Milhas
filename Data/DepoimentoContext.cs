using api_alura_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace api_alura_challenge.Data
{
    public class DepoimentoContext :DbContext
    {
        public DepoimentoContext(DbContextOptions<DepoimentoContext> opts)
            : base(opts) { }

        public DbSet<Depoimento> Depoimentos { get; set; }
    }
}
