using AutoMapper;
<<<<<<< HEAD
using backendAPI.Data.Entities.category;
using backendAPI.Models.Category;
=======
>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843

namespace backendAPI.Mapper
{
    public class AppMapProfile : Profile
    {

        public AppMapProfile()
        {
<<<<<<< HEAD
            CreateMap<CategoryEntity, CategoryViewModel>()
                .ForMember(x => x.ParentCategoryId, opt => opt.MapFrom(x => x.Name));

            CreateMap<CategoryViewModel, CategoryEntity>()
                .ForMember(x => x.ParentCategoryId, opt => opt.MapFrom(x => x.ParentCategoryId == 0 ? null : x.ParentCategoryId));
               // .ForMember(x => x.image, opt => opt.Ignore());

            //CreateMap<ProductImageEntity, ProdcutImageItemViewModel>();
=======

>>>>>>> f0834f38439bff0e5bd32e05f7d5e1b133f7b843
        }
    }
}
