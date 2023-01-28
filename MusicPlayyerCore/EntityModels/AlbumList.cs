using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.EntityModels
{
    public class AlbumList: SqueezeBase
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "albums_loop")]
        public List<Album> Albums { get; set; }
    }
}
