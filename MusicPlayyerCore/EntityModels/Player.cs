using MusicPlayerCore.Abstract;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;

namespace MusicPlayerCore.EntityModels
{
    public class Player: SqueezeBase
    {
        [JsonProperty(PropertyName = "playerid")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public string UUID { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string IP { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "displaytype")]
        public string DisplayType { get; set; }

        [JsonProperty(PropertyName = "connected")]
        public bool Connected { get; set; }

        [JsonProperty(PropertyName = "isplayer")]
        public bool IsPlayer { get; set; }

        [JsonProperty(PropertyName = "canpoweroff")]
        public bool CanPowerOff { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ArtworkUrl
        {
            get
            {
                string imageLocation = string.Format(@"html/images/Players/{0}_75x75_ffffff.png", Model);
                return string.Format("{0}{1}", SqueezeConfig.RemoteUrl, imageLocation);
            }
        }
    }
}

