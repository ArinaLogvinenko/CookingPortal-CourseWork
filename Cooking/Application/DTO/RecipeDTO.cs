using System.Collections.Generic;

namespace Application.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Image { get; set; }

        public string ServingTime { get; set; }

        public string NutritionFacts { get; set; }

        public int Likes { get; set; }

        public bool IsSaved { get; set; }

        public bool IsFollowToAuthor { get; set; }

        public List<RecipeCommentDTO> Comments { get; set; }

        public UserDTO Author { get; set; }
    }
}
