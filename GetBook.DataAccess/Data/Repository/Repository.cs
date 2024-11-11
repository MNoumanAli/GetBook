using GetBook.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GetBook.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbset;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }
        public void Add(T item)
        {
            dbset.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var data = dbset.Where(filter);
            return data.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();   
        }

        public void Remove(T item)
        {
            dbset.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            dbset.RemoveRange(items);
        }
    }
}
