using Newtonsoft.Json;

namespace LaunchAPIConsole.Data.ApiModels.SpaceX.Launches
{
    public class SpaceXLinks
    {
        [JsonProperty(PropertyName = "mission_patch")]
        public string MissionPatch { get; set; }

        [JsonProperty(PropertyName = "mission_patch_small")]
        public string MissionPatchSmall { get; set; }

        [JsonProperty(PropertyName = "reddit_campaign")]
        public string RedditCampaign { get; set; }

        [JsonProperty(PropertyName = "reddit_launch")]
        public string RedditLaunch { get; set; }

        [JsonProperty(PropertyName = "reddit_recovery")]
        public string RedditRecovery { get; set; }

        [JsonProperty(PropertyName = "reddit_media")]
        public string RedditMedia { get; set; }

        public string PressKit { get; set; }

        [JsonProperty(PropertyName = "article_link")]
        public string ArticleLink { get; set; }

        public string Wikipedia { get; set; }

        [JsonProperty(PropertyName = "video_link")]
        public string VideoLink { get; set; }

        [JsonProperty(PropertyName = "youtube_id")]
        public string YoutubeId { get; set; }

        [JsonProperty(PropertyName = "flickr_images")]
        public string[] FlickrImages { get; set; }
    }
}
