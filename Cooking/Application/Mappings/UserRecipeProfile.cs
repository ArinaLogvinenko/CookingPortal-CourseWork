namespace Application.Mappings
{
    using AutoMapper;
    using DTO;
    using Domain.Entities;

    public class UserRecipeProfile : Profile
    {
        public UserRecipeProfile()
        {
            CreateMap<User, UserRecipeDTO>().ForMember(d => d.UserImage, o => o.MapFrom(src => src.Image));
            CreateMap<Recipe, UserRecipeDTO>().ForMember(d => d.RecipeImage, o => o.MapFrom(src => src.Image));
        }
    }
}
