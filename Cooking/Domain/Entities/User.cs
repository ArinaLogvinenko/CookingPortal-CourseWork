namespace Domain.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string FullName { get; set; }

        [MaxLength(15)]
        public string Status { get; set; }

        public string Image { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public PersonalSettings PersonalSettings { get; set; }

        public NotificationSettings NotificationSettings { get; set; }

        public ICollection<User> Followers { get; set; } = new List<User>();

        public ICollection<User> Following { get; set; } = new List<User>();

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public ICollection<Recipe> SavedRecipes { get; set; } = new List<Recipe>();

        public List<RecipeComment> Comments { get; set; } = new List<RecipeComment>();

        public ICollection<UsersFollowings> UserFollowings { get; set; } = new List<UsersFollowings>();

        public ICollection<RecipesFollowings> RecipeFollowings { get; set; } = new List<RecipesFollowings>();

        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    }
}
