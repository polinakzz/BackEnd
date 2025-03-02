using Microsoft.EntityFrameworkCore;

namespace Lab12._1.Model
{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BackEnd;Username=postgres;Password=Qweasd123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
    }
}
