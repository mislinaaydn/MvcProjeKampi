using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class //şartımız t değerinin  class (entity) olması
    {
        Context c = new Context();//contenxt sınıfından bir nesne türettik
        DbSet<T> _object; //_object t değerine gelen değeri tutar

        public GenericRepository()
        {
            _object = c.Set<T>(); // objectin değeri context e bağlı olarak gelen t değeri ataması
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); 
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
