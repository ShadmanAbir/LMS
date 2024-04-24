using AutoMapper;
using LMS.API.ViewModels;
using LMS.Core.Interfaces;
using LMS.Domain.Models;
using LMS.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public AuthorService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Add(AuthorsViewModel authorVM)
        {
            var Author = _mapper.Map<Authors>(authorVM);
            _unitOfWork.AuthorRepository.Insert(Author);
            _unitOfWork.Save();
            return Author.AuthorID;
        }

        public int Delete(int ID)
        {
            var Author = _unitOfWork.AuthorRepository.GetByID(ID);
            _unitOfWork.AuthorRepository.Delete(Author);
            return _unitOfWork.Save();
        }

        public List<AuthorsViewModel> Get()
        {
            var Authors = _unitOfWork.AuthorRepository.Get();
            var result = _mapper.ProjectTo<AuthorsViewModel>(Authors).ToList();
            return result;
        }

        public AuthorsViewModel GetByID(int ID)
        {
            var Author = _unitOfWork.AuthorRepository.GetByID(ID);
            var result = _mapper.Map<AuthorsViewModel>(Author);
            return result;
        }

        public int Update(AuthorsViewModel authorVM)
        {
            var Author = _unitOfWork.AuthorRepository.GetByID(authorVM.AuthorID);
            Author.AuthorBio = authorVM.AuthorBio;
            Author.AuthorName = authorVM.AuthorName;
            _unitOfWork.AuthorRepository.Update(Author);
            _unitOfWork.Save();
            return Author.AuthorID;
        }
    }
}
