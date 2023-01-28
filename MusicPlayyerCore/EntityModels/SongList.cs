using MusicPlayerCore.Abstract;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusicPlayerCore.EntityModels
{
    public class SongList: SqueezeBase
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "titles_loop")]
        public List<Song> Songs { get; set; }
    }
}
