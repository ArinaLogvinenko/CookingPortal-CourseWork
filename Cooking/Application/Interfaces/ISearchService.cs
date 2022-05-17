namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTO;

    public interface ISearchService : IService
    {
        Task<IEnumerable<UserRecipeDTO>> GetUserAndRecipeByString(string expression);
    }
}
