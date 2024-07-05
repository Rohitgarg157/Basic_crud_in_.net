using Microsoft.EntityFrameworkCore;

namespace crud_demo.Models
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseMySQL("server=localhost;database=cruddemo;user=root;password=Rohit@157");
            }
        }


            public AppDbcontext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
    }
}
