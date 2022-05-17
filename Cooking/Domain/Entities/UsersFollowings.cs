namespace Domain.Entities
{
    public class UsersFollowings
    {
        public int FollowerId { get; set; }

        public User Follower { get; set; }

        public int FollowingsId { get; set; }

        public User Followings { get; set; }
    }
}
