using Microsoft.EntityFrameworkCore;
using Persons.Entities;

namespace PersonDatabase.PostgresContext
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<PersonsEntity> PersonsInfo { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
