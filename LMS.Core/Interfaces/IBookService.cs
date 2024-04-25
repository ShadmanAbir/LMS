using LMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IBookService
    {
        public List<BooksViewModel> Get();
        public BooksViewModel GetByID(int ID);
        public int Add(BooksViewModel bookVM);
        public int Update(BooksViewModel bookVM);
        public int Delete(int ID);
    }
}
