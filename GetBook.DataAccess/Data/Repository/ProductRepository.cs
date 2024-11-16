using GetBook.DataAccess.Data.Repository.IRepository;
using GetBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBook.DataAccess.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            _db.Product.Update(product);
        }
    }
}
