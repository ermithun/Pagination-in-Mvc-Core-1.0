using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Models
{
    public class MithunDbContext : DbContext
    {
        public MithunDbContext()
        {
        }

        public MithunDbContext(DbContextOptions<MithunDbContext> options)
           : base(options)
        { }

        public IConfigurationRoot Configuration { get; set; }
        //public IServiceCollection services { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configuration.Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }


        
        public DbSet<Product> Product { get; set; }
    }
}
