using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        
        public  Task<List<Product>> GetTopPriceProductAsync(int count)
        {
            return  Context.Products.OrderByDescending(p=> p.Price)
                .Take(count)
                .ToListAsync(); //Asenkron bir işlem olduğu için await kullandık. Entity Framework Core'da DbSet sınıfı, veritabanındaki bir tabloyu temsil eder. Bu nedenle, DbSet<Product> türünde bir değişken tanımladık.
        }
    }
    
}
