﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetBook.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        public void Save();
    }
}
