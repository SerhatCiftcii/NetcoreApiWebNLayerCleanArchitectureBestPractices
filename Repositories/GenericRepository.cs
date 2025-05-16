using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();
        public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking(); //queryable döndürdük çünkü veritabanına erişim yapmadan önce filtreleme yapabilmek için.
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking(); //şartlı sorgulama yapabilmek için. IQueryable döndürdük çünkü veritabanına erişim yapmadan önce filtreleme yapabilmek için.

        public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id); //id'ye göre bulmak için. Asenkron bir işlem olduğu için ValueTask döndürdük.

        public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity); //Asenkron bir işlem olduğu için await kullandık. Entity Framework Core'da DbSet sınıfı, veritabanındaki bir tabloyu temsil eder. Bu nedenle, DbSet<T> türünde bir değişken tanımladık.

        public void Update(T entity) => _dbSet.Update(entity); //Asenkron bir işlem olmadığı için await kullanmadık. Entity Framework Core'da DbSet sınıfı, veritabanındaki bir tabloyu temsil eder. Bu nedenle, DbSet<T> türünde bir değişken tanımladık.

        public void Delete(T entity) => _dbSet.Remove(entity);



    }
}
