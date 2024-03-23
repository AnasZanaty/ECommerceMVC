using AutoMapper;
using Demo.DAL.Entities;
using session3_MVC.Models;

namespace session3_MVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        
        
        
        
        }
    }
}
