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
    public class MemberService : IMemberService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public MemberService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Add(MembersViewModel memberVM)
        {
            var Member = _mapper.Map<Members>(memberVM);
            Member.RegistrationDate = DateTime.Now;
            _unitOfWork.MemberRepository.Insert(Member);
            _unitOfWork.Save();
            return Member.MemberID;
        }

        public int Delete(int ID)
        {
            var Author = _unitOfWork.MemberRepository.GetByID(ID);
            _unitOfWork.MemberRepository.Delete(Author);
            return _unitOfWork.Save();
        }

        public List<MembersViewModel> Get()
        {
            var Members = _unitOfWork.MemberRepository.Get();
            var result = _mapper.ProjectTo<MembersViewModel>(Members).ToList();
            return result;
        }

        public MembersViewModel GetByID(int ID)
        {
            var Member = _unitOfWork.MemberRepository.GetByID(ID);
            var result = _mapper.Map<MembersViewModel>(Member);
            return result;
        }

        public int Update(MembersViewModel memberVM)
        {
            var Member = _unitOfWork.MemberRepository.GetByID(memberVM.MemberID);
            if (Member == null)
                throw new Exception("Member Not Found");
            Member.FirstName = memberVM.FirstName;
            Member.LastName = memberVM.LastName;
            Member.Email = memberVM.Email;
            Member.PhoneNumber = memberVM.PhoneNumber;
            _unitOfWork.MemberRepository.Update(Member);
            _unitOfWork.Save();
            return Member.MemberID;
        }
    }
}
