using AutoMapper;
using LMS.Core.ViewModels;
using LMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Authors, AuthorsViewModel>().ReverseMap();
        }
    }
}
