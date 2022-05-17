namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public string Image { get; set; }

        public bool IsFollowToAuthor { get; set; }

        public int Follower { get; set; }

        public int Following { get; set; }
    }
}
