using LMS.Domain.Models;
using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private LMSContext _context;


        public UnitOfWork(LMSContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        /*private GenericRepository<Product> productRepository;
        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }*/
    }
}
