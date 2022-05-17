namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class NotificationSettings
    {
        [Key]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public bool PushNewFollowerNotify { get; set; }

        [Required]
        public bool PushNewMessageNotify { get; set; }

        [Required]
        public bool PushLikeNotify { get; set; }
    }
}
