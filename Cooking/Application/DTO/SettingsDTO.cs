namespace Application.DTO
{
    public class SettingsDTO
    {
        public bool PushNewFollowerNotify { get; set; }

        public bool PushNewMessageNotify { get; set; }

        public bool PushLikeNotify { get; set; }

        public bool FollowerSeeSavedRecipe { get; set; }

        public bool FollowerSeeFollowers { get; set; }

        public string TimeZone { get; set; }
    }
}
