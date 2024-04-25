using AutoMapper;
using LMS.Core.ViewModels;
using LMS.Domain.Models;

namespace LMS.Core.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Authors, AuthorsViewModel>().ReverseMap();
            CreateMap<Books, BooksViewModel>().ReverseMap();
            CreateMap<Members, MembersViewModel>().ReverseMap();
            CreateMap<BorrowedBooks, BorrowedBooksViewModel>().ReverseMap();
        }
    }
}
