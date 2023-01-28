
using MusicPlayerCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class GetPlayerStatusCompletedEventArgs: EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the GetPlayerStatusCompletedEventArgs class from the
        /// specified instance of the PlayerStatus class
        /// </summary>
        /// <param name="serverStatus">A ServerStatus class that contains the statuc of the server</param>
        public GetPlayerStatusCompletedEventArgs(PlayerStatus playerStatus)
        {
            this.playerStatus = playerStatus;
        }

        private PlayerStatus playerStatus;

        /// <summary>
        /// Requested Serverstatus
        /// </summary>
        public PlayerStatus PlayerStatus
        {
            get { return playerStatus; }
        }
    }
}
