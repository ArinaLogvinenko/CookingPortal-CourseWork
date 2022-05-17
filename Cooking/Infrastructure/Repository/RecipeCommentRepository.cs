using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RecipeCommentRepository : Repository<RecipeComment>, IRecipeCommentRepository
    {
        public RecipeCommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Add(AddRecipeCommentDTO comment)
        {
            var com = new RecipeComment()
            {
                Comment = comment.Comment
            };

            var recipe = await Context.Recipes
                   .Where(x => x.Id == comment.RecipeId)
                   .Include(x => x.Comments)
                   .FirstAsync();

            var author = await Context.Users
                .Where(x => x.Id == comment.AuthorId)
                .Include(x => x.Comments)
                .FirstAsync();

            recipe.Comments.Add(com);
            author.Comments.Add(com);

            await Context.SaveChangesAsync();
        }
    }
}
