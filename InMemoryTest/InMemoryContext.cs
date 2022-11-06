using InMemoryTest.ClaimRecoveries;
using Microsoft.EntityFrameworkCore;

namespace InMemoryTest
{
    public class InMemoryContext: DbContext
    {
        public InMemoryContext(DbContextOptions options) : base(options) { }

        public DbSet<ClaimRecovery> ClaimRecoveries { get; set; }
    }
}
