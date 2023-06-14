using AutoMapper;
using Bizcom.Application.Models.VIewModels;
using Bizcom.Application.UseCases.Authorize.Commands;
using Bizcom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<RegisterCommand, User>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<List<User>, List<UserViewModel>>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}
