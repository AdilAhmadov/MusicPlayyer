
using MusicPlayerCore.BussnessEventArgs;
using MusicPlayerCore.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MusicPlayerCore.HTTPHellpers
{
    public class JsonHelper
    {
        public event System.EventHandler<SqueezeErrorEventArgs> OnError;
        public event JsonResponseCompleteEventHandler ResponseComplete;
        public delegate void JsonResponseCompleteEventHandler(JsonResponseCompleteEventArgs e);
        private void SetErrorHandler(HttpConnection helper)
        {
            helper.OnError += (e, args) =>
            {
                if (OnError != null)
                {
                    OnError(null, args);
                }
            };
        }
        protected T Deserialize<T>(string jsonMessage)
           where T : SqueezeBase
        {
            JObject o = JObject.Parse(jsonMessage);
            var jsonResult = o["result"];
            return JsonConvert.DeserializeObject<T>(jsonResult.ToString());
        }
        
        public void BeginSendCommandAsync<T>(string username, string password, string url, string jsonText)
           where T : SqueezeBase
        {
            // Create a new HttpHelper which is used to post and retreve data from the SqueezeBox Web server
            HttpConnection helper = new HttpConnection(new Uri(url), username, password, "POST", "application/json", jsonText);
            SetErrorHandler(helper);

            helper.ResponseComplete += (e) =>
            {
                // The requested data is deserialized into the requested type
                T t = Deserialize<T>(e.Response);

                // And inform anyone who is listening....
                if (ResponseComplete != null)
                {
                    ResponseComplete(new JsonResponseCompleteEventArgs(t));
                }
            };

            // Start communication async
            helper.ExecuteAsync();
        }
    }
}
