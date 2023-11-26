using AutoMapper;
using backendAPI.Data.Entities;
using backendAPI.Models;

namespace backendAPI.Mapper
{
    public class AppMapProfile : Profile
    {

        public AppMapProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
