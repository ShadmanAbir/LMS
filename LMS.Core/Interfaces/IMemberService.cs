using LMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IMemberService
    {
        public List<MembersViewModel> Get();
        public MembersViewModel GetByID(int ID);
        public int Add(MembersViewModel memberVM);
        public int Update(MembersViewModel memberVM);
        public int Delete(int ID);
    }
}
