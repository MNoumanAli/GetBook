using GetBook.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBook.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ApplicationDBContext db) 
        { 
            _db = db;
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);    
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
