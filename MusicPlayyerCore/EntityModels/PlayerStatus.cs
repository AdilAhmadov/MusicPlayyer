using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.EntityModels
{
    public class PlayerStatus: SqueezeBase
    {
        [JsonProperty(PropertyName = "seq_no")]
        public int SequenceNumber { get; set; }

        [JsonProperty(PropertyName = "mixer volume")]
        public int MixerVolume { get; set; }

        [JsonProperty(PropertyName = "playlist_tracks")]
        public int PlaylistTracksCount { get; set; }

        [JsonProperty(PropertyName = "player_connected")]
        public bool PlayerConnected { get; set; }

        [JsonProperty(PropertyName = "time")]
        public int Time { get; set; }

        [JsonProperty(PropertyName = "mode")]
        public PlayerMode Mode { get; set; }

        [JsonProperty(PropertyName = "playlist_timestamp")]
        public string PlaylistTimestamp { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public int Rate { get; set; }

        [JsonProperty(PropertyName = "can_seek")]
        public bool CanSeek { get; set; }

        [JsonProperty(PropertyName = "power")]
        public bool Power { get; set; }

        [JsonProperty(PropertyName = "playlist mode")]
        public string PlaylistMode { get; set; }

        [JsonProperty(PropertyName = "playlist repeat")]
        public bool PlaylistRepeat { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public double Duration { get; set; }

        [JsonProperty(PropertyName = "playlist_cur_index")]
        public int PlaylistCurrentIndex { get; set; }

        [JsonProperty(PropertyName = "signalstrength")]
        public int SignalStrength { get; set; }

        [JsonProperty(PropertyName = "playlist shuffle")]
        public bool PlaylistShuffle { get; set; }

        [JsonProperty(PropertyName = "player_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "player_ip")]
        public string IP { get; set; }

        [JsonProperty(PropertyName = "playlist_loop")]
        public List<Song> Playlist { get; set; }
    }
}
