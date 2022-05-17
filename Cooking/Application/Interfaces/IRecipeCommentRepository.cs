using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecipeCommentRepository : IRepository<RecipeComment>
    {
        Task Add(AddRecipeCommentDTO comment);
    }
}
