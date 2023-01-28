
using MusicPlayerCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.BussnessEventArgs

{
    public class GetPlayersCompletedEventArgs: EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the GetPlayersCompletedEventArgs class from the
        /// specified instance of the PlayerList class
        /// </summary>
        /// <param name="playerList">An PlayerList class that contains the list of players</param>
        public GetPlayersCompletedEventArgs(PlayerList playerList)
        {
            this.playerList = playerList;
        }

        private PlayerList playerList;

        /// <summary>
        /// List of requested players
        /// </summary>
        public List<Player> Players
        {
            get { return playerList.Players; }
        }
    }
}
