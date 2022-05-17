namespace Application.DTO
{
    public class AddRecipeCommentDTO
    {
        public int RecipeId { get; set; }

        public int AuthorId { get; set; }

        public string Comment { get; set; }
    }
}
