namespace Domain.Entities
{
    public class RecipesFollowings
    {
        public int FollowerId { get; set; }

        public User Follower { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
