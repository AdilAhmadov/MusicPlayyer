
using MusicPlayerCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class GetArtistsCompletedEventArgs: EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the GetArtistsCompletedEventArgs class from the
        /// specified instance of the ArtistList class
        /// </summary>
        /// <param name="artists">An ArtistList class that contains the list of artists</param>
        public GetArtistsCompletedEventArgs(ArtistList artists)
        {
            this.artistList = artists;
        }

        private ArtistList artistList;

        /// <summary>
        /// List of requested artists
        /// </summary>
        public List<Artist> Artists
        {
            get { return artistList.Artists; }
        }
    }
}
