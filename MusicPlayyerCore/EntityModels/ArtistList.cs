using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusicPlayerCore.EntityModels
{
    public class ArtistList : SqueezeBase
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "artists_loop")]
        public List<Artist> Artists { get; set; }
    }
}
