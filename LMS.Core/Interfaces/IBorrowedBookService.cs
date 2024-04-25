using LMS.Core.ViewModels;

namespace LMS.Core.Interfaces
{
    public interface IBorrowedBookService
    {
        public List<BorrowedBooksViewModel> Get();
        public BorrowedBooksViewModel GetByID(int ID);
        public int Add(BorrowedBooksViewModel borrowedBooksVM);
        public int Update(BorrowedBooksViewModel borrowedBooksVM);
        public int Delete(int ID);
    }
}
