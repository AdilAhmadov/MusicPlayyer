using MusicPlayerCore.Abstract;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;

namespace MusicPlayerCore.EntityModels
{
    public class Album : SqueezeBase
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "album")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "artwork_track_id")]
        public string ArtworkID { get; set; }

        private string GetArtworkUrl(int size)
        {
            return string.Format("{0}music/{1}/cover_{2}x{2}.jpg", SqueezeConfig.RemoteUrl, string.IsNullOrEmpty(ArtworkID) ? "0" : ArtworkID, size);
        }

        public string ArtworkUrl
        {
            get
            {
                return GetArtworkUrl(SqueezeConfig.BigImageSize);
            }
        }

        public string ArtworkUrl_Small
        {
            get
            {
                return GetArtworkUrl(SqueezeConfig.SmallImageSize);
            }
        }
    }
}
