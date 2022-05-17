using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class RecipeComment
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public Recipe Recipe { get; set; }

        public User Author { get; set; }

        public string Comment { get; set; }
    }
}
