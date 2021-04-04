using System;
using Newtonsoft.Json;

namespace ImageUrlScraper.ApiClients.Responses
{ 
    public class GalleriesResponse
    {
        [JsonProperty("data")]
        public Gallery[] Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public class Gallery
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("cover_width")]
        public long CoverWidth { get; set; }

        [JsonProperty("cover_height")]
        public long CoverHeight { get; set; }

        [JsonProperty("account_url")]
        public string AccountUrl { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("ups")]
        public long Ups { get; set; }

        [JsonProperty("downs")]
        public long Downs { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("is_album")]
        public bool IsAlbum { get; set; }

        [JsonProperty("vote")]
        public object Vote { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("comment_count")]
        public long CommentCount { get; set; }

        [JsonProperty("favorite_count")]
        public long FavoriteCount { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("topic_id")]
        public long? TopicId { get; set; }

        [JsonProperty("images_count")]
        public long ImagesCount { get; set; }

        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty("ad_type")]
        public long AdType { get; set; }

        [JsonProperty("ad_url")]
        public string AdUrl { get; set; }

        [JsonProperty("in_most_viral")]
        public bool InMostViral { get; set; }

        [JsonProperty("include_album_ads")]
        public bool IncludeAlbumAds { get; set; }

        [JsonProperty("images")]
        public ImgurImage[] Images { get; set; }

        [JsonProperty("ad_config")]
        public AdConfig AdConfig { get; set; }
    }

    public class AdConfig
    {
        [JsonProperty("safeFlags")]
        public string[] SafeFlags { get; set; }

        [JsonProperty("highRiskFlags")]
        public object[] HighRiskFlags { get; set; }

        [JsonProperty("unsafeFlags")]
        public string[] UnsafeFlags { get; set; }

        [JsonProperty("wallUnsafeFlags")]
        public string[] WallUnsafeFlags { get; set; }

        [JsonProperty("showsAds")]
        public bool ShowsAds { get; set; }
    }

    public class ImgurImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("bandwidth")]
        public long Bandwidth { get; set; }

        [JsonProperty("vote")]
        public object Vote { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("nsfw")]
        public object Nsfw { get; set; }

        [JsonProperty("section")]
        public object Section { get; set; }

        [JsonProperty("account_url")]
        public object AccountUrl { get; set; }

        [JsonProperty("account_id")]
        public object AccountId { get; set; }

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        [JsonProperty("in_most_viral")]
        public bool InMostViral { get; set; }

        [JsonProperty("has_sound")]
        public bool HasSound { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("ad_type")]
        public long AdType { get; set; }

        [JsonProperty("ad_url")]
        public string AdUrl { get; set; }

        [JsonProperty("edited")]
        public long Edited { get; set; }

        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("comment_count")]
        public object CommentCount { get; set; }

        [JsonProperty("favorite_count")]
        public object FavoriteCount { get; set; }

        [JsonProperty("ups")]
        public object Ups { get; set; }

        [JsonProperty("downs")]
        public object Downs { get; set; }

        [JsonProperty("points")]
        public object Points { get; set; }

        [JsonProperty("score")]
        public object Score { get; set; }

        [JsonProperty("mp4_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? Mp4Size { get; set; }

        [JsonProperty("mp4", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Mp4 { get; set; }

        [JsonProperty("gifv", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Gifv { get; set; }

        [JsonProperty("hls", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Hls { get; set; }

        [JsonProperty("processing", NullValueHandling = NullValueHandling.Ignore)]
        public Processing Processing { get; set; }

        [JsonProperty("looping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Looping { get; set; }
    }

    public class Processing
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }

        [JsonProperty("total_items")]
        public long TotalItems { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        [JsonProperty("background_hash")]
        public string BackgroundHash { get; set; }

        [JsonProperty("thumbnail_hash")]
        public string ThumbnailHash { get; set; }

        [JsonProperty("accent")]
        public string Accent { get; set; }

        [JsonProperty("background_is_animated")]
        public bool BackgroundIsAnimated { get; set; }

        [JsonProperty("thumbnail_is_animated")]
        public bool ThumbnailIsAnimated { get; set; }

        [JsonProperty("is_promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("logo_hash")]
        public object LogoHash { get; set; }

        [JsonProperty("logo_destination_url")]
        public object LogoDestinationUrl { get; set; }
    }
}