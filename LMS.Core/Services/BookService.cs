using AutoMapper;
using LMS.Core.Interfaces;
using LMS.Core.ViewModels;
using LMS.Domain.Models;
using LMS.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public BookService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Add(BooksViewModel bookVM)
        {
            var Book = _mapper.Map<Books>(bookVM);
            _unitOfWork.BookRepository.Insert(Book);
            _unitOfWork.Save();
            return Book.BookID;
        }

        public int Delete(int ID)
        {
            var Author = _unitOfWork.AuthorRepository.GetByID(ID);
            _unitOfWork.AuthorRepository.Delete(Author);
            return _unitOfWork.Save();
        }

        public List<BooksViewModel> Get()
        {
            var Books = _unitOfWork.AuthorRepository.Get();
            var result = _mapper.ProjectTo<BooksViewModel>(Books).ToList();
            return result;
        }

        public BooksViewModel GetByID(int ID)
        {
            var Book = _unitOfWork.BookRepository.GetByID(ID);
            var result = _mapper.Map<BooksViewModel>(Book);
            return result;
        }

        public int Update(BooksViewModel bookVM)
        {
            var Book = _unitOfWork.BookRepository.GetByID(bookVM.BookID);
            if (Book == null)
                throw new Exception("Book Not Found");
            Book.Title = bookVM.Title;
            Book.TotalCopies = bookVM.TotalCopies;
            Book.ISBN = bookVM.ISBN;
            Book.PublishedDate = bookVM.PublishedDate;
            Book.AuthorID = bookVM.AuthorID;
            _unitOfWork.BookRepository.Update(Book);
            _unitOfWork.Save();
            return Book.BookID;
        }
    }
}
