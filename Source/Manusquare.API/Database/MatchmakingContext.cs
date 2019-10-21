using Manusquare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Manusquare.API.Database
{

    public class MatchmakingContext : DbContext
    {
        public MatchmakingContext(DbContextOptions<MatchmakingContext> options)
            : base(options)
        {
        }

        public DbSet<TransactionalData> TransactionalData { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
    }
}