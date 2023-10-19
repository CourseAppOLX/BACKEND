using AutoMapper;
using backendAPI.Data.Entities.category;
using backendAPI.Models.Category;

namespace backendAPI.Mapper
{
    public class AppMapProfile : Profile
    {

        public AppMapProfile()
        {
            CreateMap<CategoryEntity, CategoryViewModel>()
                .ForMember(x => x.ParentCategoryId, opt => opt.MapFrom(x => x.Name));

            CreateMap<CategoryViewModel, CategoryEntity>()
                .ForMember(x => x.ParentCategoryId, opt => opt.MapFrom(x => x.ParentCategoryId == 0 ? null : x.ParentCategoryId));
               // .ForMember(x => x.image, opt => opt.Ignore());

            //CreateMap<ProductImageEntity, ProdcutImageItemViewModel>();
        }
    }
}
