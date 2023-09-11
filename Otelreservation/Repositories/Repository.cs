using Otelreservation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otelreservation.Repositories
{
    public class Repository<T> where T : class,new()
    {
        DbOtelEntities db = new DbOtelEntities();

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TRemove(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T Get(int id)
        {
          return db.Set<T>().Find(id);
        }

        public void TUpdate() 
        {
            db.SaveChanges();
        }
    }
}
