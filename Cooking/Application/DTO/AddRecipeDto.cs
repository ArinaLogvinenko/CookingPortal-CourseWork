using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class AddRecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Image { get; set; }

        public string ServingTime { get; set; }

        public string NutritionFacts { get; set; }

        public int Likes { get; set; }

        public int UserId { get; set; } 
    }
}
