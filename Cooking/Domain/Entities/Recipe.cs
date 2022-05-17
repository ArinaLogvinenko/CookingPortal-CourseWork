namespace Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Ingredients { get; set; }

        public string Image { get; set; }

        [StringLength(500)]
        public string ServingTime { get; set; }

        [StringLength(500)]
        public string NutritionFacts { get; set; }

        public int Likes { get; set; }

        public User Author { get; set; }

        public List<RecipeComment> Comments { get; set; }

        public ICollection<User> Followers { get; set; } = new List<User>();

        public ICollection<RecipesFollowings> RecipeFollowings { get; set; } = new List<RecipesFollowings>();
    }
}
