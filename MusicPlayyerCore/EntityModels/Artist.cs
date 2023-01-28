using MusicPlayerCore.Abstract;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.EntityModels
{
    public class Artist: SqueezeBase
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "artist")]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
