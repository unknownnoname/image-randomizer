using System.Runtime.Serialization;

namespace ImageRandomizer.Options
{
    [DataContract]
    public class ImgurClientOptions
    {
        public string ClientKey { get; set; }

        public string ClientSecret { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

        public string AccountUsername { get; set; }
        
        public string BaseAddress { get; set; }

        public int AccountId { get; set; }

        public int ExpiresIn { get; set; }
    }
}