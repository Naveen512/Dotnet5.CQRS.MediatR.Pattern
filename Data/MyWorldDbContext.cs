using API.CQRS.Sample.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace API.CQRS.Sample.Data
{
     public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(build => {
                build.HasKey(_ => _.ProductId);
            });
        }
    }
}