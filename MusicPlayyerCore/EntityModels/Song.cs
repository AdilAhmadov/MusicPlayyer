using MusicPlayerCore.Abstract;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System;

namespace MusicPlayerCore.EntityModels
{
    public class Song : SqueezeBase
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }

        [JsonProperty(PropertyName = "artist_id")]
        public string ArtistID { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "genre_id")]
        public string GenreID { get; set; }

        [JsonProperty(PropertyName = "album_id")]
        public string AlbumID { get; set; }

        [JsonProperty(PropertyName = "album")]
        public string Album { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public double Duration { get; set; }

        [JsonProperty(PropertyName = "tracknum")]
        public string Tracknum { get; set; }

        [JsonProperty(PropertyName = "playlist index")]
        public string PlaylistIndex { get; set; }

        [JsonProperty(PropertyName = "coverart")]
        public string CoverArt { get; set; }

        [JsonProperty(PropertyName = "lyrics")]
        public string Lyrics { get; set; }

        [JsonProperty(PropertyName = "artwork_track_id")]
        public string ArtworkID { get; set; }

        [JsonProperty(PropertyName = "remote")]
        public string IsRemote { get; set; }

        [JsonProperty(PropertyName = "remote_title")]
        public string RemoteTitle { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string ContentType { get; set; }

        public string TracknumSort
        {
            get
            {
                if (string.IsNullOrEmpty(Tracknum))
                {
                    return string.Empty;
                }
                else
                {
                    return Tracknum.PadLeft(2, '0');
                }
            }
        }
        public string PlaylistIndexSort
        {
            get
            {
                if (string.IsNullOrEmpty(PlaylistIndex))
                {
                    return string.Empty;
                }
                else
                {
                    return PlaylistIndex.PadLeft(2, '0');
                }
            }
        }

        public string DurationText
        {
            get
            {
                TimeSpan duration = TimeSpan.FromSeconds(Duration);
                return string.Format("{0:00}:{1:00}:{2:00}", duration.TotalHours, duration.Minutes, duration.Seconds);
            }
        }

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

        public override string ToString()
        {
            return string.Format("{0}", Title);
        }
    }
}
