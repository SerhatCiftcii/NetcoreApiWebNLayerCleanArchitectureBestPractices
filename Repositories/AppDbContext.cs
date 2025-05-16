using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //buraya yazmak erine ayrı classlar için ayrı ayrı yazmak daha mantıklı
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //IEntityTypeConfiguration interface'ini implement eden classları bul ve uygula hepsi için basit kullanım.




            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Product> Products { get; set; } = default!;
    }
}
