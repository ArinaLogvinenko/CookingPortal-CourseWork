namespace Application.Mappings
{
    using AutoMapper;
    using DTO;
    using Services;
    using Domain.Entities;
    using System.Linq;

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember("Follower", opt => opt.MapFrom(src => src.Followers.Count))
                .ForMember("Following", opt => opt.MapFrom(src => src.Following.Count));
            CreateMap<AddUserDTO, User>()
                .ForMember("Password", opt => opt.MapFrom(src => CryptographyService.ComputeHash(src.Password)));
            CreateMap<EditUserDTO, User>()
                .ForMember("Password", opt => opt.MapFrom(src => CryptographyService.ComputeHash(src.Password)))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RegisterUserDTO, User>();

            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeComment, RecipeCommentDTO>();
        }
    }
}
