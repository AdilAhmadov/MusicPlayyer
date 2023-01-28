using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MusicPlayerCore.EntityModels
{
    public class PlayerList: SqueezeBase
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "players_loop")]
        public List<Player> Players { get; set; }
    }
}
