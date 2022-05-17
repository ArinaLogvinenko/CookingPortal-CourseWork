namespace CookingPortal.Models
{
    public class AddRecipeCommentModel
    {
        public int RecipeId { get; set; }

        public int AuthorId { get; set; }

        public string Comment { get; set; }
    }
}
