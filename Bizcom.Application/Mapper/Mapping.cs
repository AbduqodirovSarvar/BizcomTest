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
           /* CreateMap<User, UserViewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Phone, y => y.MapFrom(z => z.Phone));*/
            CreateMap<List<User>, List<UserViewModel>>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}
