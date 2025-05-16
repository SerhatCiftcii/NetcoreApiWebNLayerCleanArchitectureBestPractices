using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    //en fazla bu kadar generic olabilir. fazla şişirmemek gerekir.Fazlalıklara ayrı bir reposrty  class eklenebilir.kendine ait methodları olabilir bazen gibi gibi.
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<T?> GetByIdAsync(int id);
        //Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll(); //queryable döndürdük çünkü veritabanına erişim yapmadan önce filtreleme yapabilmek için.
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);//şartlı sorgulama yapabilmek için.
        ValueTask AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
       
}
