namespace Application.DTO
{
    public class RecipeCommentDTO
    {
        public int Id { get; set; }

        public RecipeDTO Recipe { get; set; }

        public UserDTO Author { get; set; }

        public string Comment { get; set; }
    }
}
