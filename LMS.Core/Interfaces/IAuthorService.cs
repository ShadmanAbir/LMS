using LMS.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IAuthorService
    {
        public List<AuthorsViewModel> Get();
        public AuthorsViewModel GetByID(int ID);
        public int Add(AuthorsViewModel authorVM);
        public int Update(AuthorsViewModel authorVM);
        public int Delete(int ID);
    }
}
