namespace CookingPortal.Mapper
{
    using Application.DTO;
    using AutoMapper;
    using CookingPortal.Models;

    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<AddRecipeCommentModel, AddRecipeCommentDTO>()
                .ReverseMap();
        }
    }
}
