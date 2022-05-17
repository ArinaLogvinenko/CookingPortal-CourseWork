namespace Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class PersonalSettings
    {
        [Key]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public bool FollowerSeeSavedRecipe { get; set; }

        [Required]
        public bool FollowerSeeFollowers { get; set; }

        [Required]
        public string TimeZone { get; set; }
    }
}
