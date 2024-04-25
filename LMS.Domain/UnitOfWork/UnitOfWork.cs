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



        private GenericRepository<Authors> authorRepository;
        public GenericRepository<Authors> AuthorRepository
        {
            get
            {

                if (this.authorRepository == null)
                {
                    this.authorRepository = new GenericRepository<Authors>(_context);
                }
                return authorRepository;
            }
        }

        private GenericRepository<Books> bookRepository;
        public GenericRepository<Books> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Books>(_context);
                }
                return bookRepository;
            }
        }
    }
}
