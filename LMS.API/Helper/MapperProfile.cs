using AutoMapper;
using LMS.API.ViewModels;
using LMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.API.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Authors, AuthorsViewModel>().ReverseMap();
        }
    }
}
