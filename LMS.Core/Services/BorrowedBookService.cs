using AutoMapper;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;
using LMS.Domain.Models;
using LMS.Domain.UnitOfWork;

namespace LMS.Core.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public BorrowedBookService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Add(BorrowedBooksViewModel borrowedbookVM)
        {
            var BorrowedBook = _mapper.Map<BorrowedBooks>(borrowedbookVM);
            
            _unitOfWork.BorrowedBookRepository.Insert(BorrowedBook);
            _unitOfWork.Save();
            return BorrowedBook.BorrowID;
        }

        public int Delete(int ID)
        {
            var Author = _unitOfWork.BorrowedBookRepository.GetByID(ID);
            _unitOfWork.BorrowedBookRepository.Delete(Author);
            return _unitOfWork.Save();
        }

        public List<BorrowedBooksViewModel> Get()
        {
            var BorrowedBooks = _unitOfWork.BorrowedBookRepository.Get();
            var result = _mapper.ProjectTo<BorrowedBooksViewModel>(BorrowedBooks).ToList();
            return result;
        }

        public BorrowedBooksViewModel GetByID(int ID)
        {
            var BorrowedBook = _unitOfWork.BorrowedBookRepository.GetByID(ID);
            var result = _mapper.Map<BorrowedBooksViewModel>(BorrowedBook);
            return result;
        }

        public int Update(BorrowedBooksViewModel borrowedbookVM)
        {
            var BorrowedBook = _unitOfWork.BorrowedBookRepository.GetByID(borrowedbookVM.BorrowID);
            if (BorrowedBook == null)
                throw new Exception("Information Not Found");

            _unitOfWork.BorrowedBookRepository.Update(BorrowedBook);
            _unitOfWork.Save();
            return BorrowedBook.BorrowID;
        }
    }
}
