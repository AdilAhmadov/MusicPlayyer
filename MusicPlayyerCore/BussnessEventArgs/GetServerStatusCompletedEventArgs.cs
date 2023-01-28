
using MusicPlayerCore.EntityModels;
using System;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class GetServerStatusCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the GetServerStatusCompletedEventArgs class from the
        /// specified instance of the ServerStatus class
        /// </summary>
        /// <param name="serverStatus">A ServerStatus class that contains the statuc of the server</param>
        public GetServerStatusCompletedEventArgs(ServerStatus serverStatus)
        {
            this.serverStatus = serverStatus;
        }

        private ServerStatus serverStatus;

        /// <summary>
        /// Requested Serverstatus
        /// </summary>
        public ServerStatus ServerStatus
        {
            get { return serverStatus; }
        }
    }
}
