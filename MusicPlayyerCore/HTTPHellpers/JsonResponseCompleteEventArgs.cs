using MusicPlayerCore.Concrete;
using System;

namespace MusicPlayerCore.HTTPHellpers
{
    public class JsonResponseCompleteEventArgs : EventArgs
    {
        public SqueezeBase Response { get; set; }

        /// <summary>
        /// Initializes a new instance of the JsonResponseCompleteEventArgs class from the
        /// specified instance of the SqueezeBase class
        /// </summary>
        /// <param name="response">Requested data</param>
        public JsonResponseCompleteEventArgs(SqueezeBase response)
        {
            this.Response = response;
        }
    }
}
