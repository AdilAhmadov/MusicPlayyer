
using MusicPlayerCore.EntityModels;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MusicPlayerCore.HTTPHellpers
{
    public class SqueezeMessage
    {
        private SqueezeMessage()
        {
            this.Method = "slim.request";
            this.ID = 1;
        }

        private SqueezeMessage(object[] Params)
            : this()
        {
            this.Params = Params;
        }

        [JsonProperty(PropertyName = "id")]
        private int ID { get; set; }

        [JsonProperty(PropertyName = "method")]
        private string Method { get; set; }

        [JsonProperty(PropertyName = "params")]
        private object[] Params { get; set; }


        public static string CreateMessage(string command)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { null, new List<string>(1) { command } }));
        }

        public static string CreateMessage(string command, string arg0)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { null, new List<string>(2) { command, arg0 } }));
        }

        public static string CreateMessage(string command, string arg0, string arg1)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { null, new List<string>(3) { command, arg0, arg1 } }));
        }

        public static string CreateMessage(string command, string arg0, string arg1, string arg2)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { null, new List<string>(4) { command, arg0, arg1, arg2 } }));
        }

        public static string CreateMessage(string command, string arg0, string arg1, string arg2, string arg3)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { null, new List<string>(4) { command, arg0, arg1, arg2, arg3 } }));
        }

        public static string CreateMessage(Player player, string command)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { player.ID, new List<string>(1) { command } }));
        }

        public static string CreateMessage(Player player, string command, string arg0)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { player.ID, new List<string>(2) { command, arg0 } }));
        }

        public static string CreateMessage(Player player, string command, string arg0, string arg1)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { player.ID, new List<string>(3) { command, arg0, arg1 } }));
        }

        public static string CreateMessage(Player player, string command, string arg0, string arg1, string arg2)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { player.ID, new List<string>(4) { command, arg0, arg1, arg2 } }));
        }

        public static string CreateMessage(Player player, string command, string arg0, string arg1, string arg2, string arg3)
        {
            return JsonConvert.SerializeObject(new SqueezeMessage(new object[2] { player.ID, new List<string>(4) { command, arg0, arg1, arg2, arg3 } }));
        }
    }
}
