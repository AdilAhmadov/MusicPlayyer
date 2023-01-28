
using MusicPlayerCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class GetAlbumsCompletedEventArgs : EventArgs
    {
        // <summary>
        /// Initializes a new instance of the GetAlbumsCompletedEventArgs class from the
        /// specified instance of the AlbumList class
        /// </summary>
        /// <param name="albums">An AlbumList class that contains the list of albums</param>
        public GetAlbumsCompletedEventArgs(AlbumList albums)
        {
            this.albumList = albums;
        }

        private AlbumList albumList;

        /// <summary>
        /// List of requested albums
        /// </summary>
        public List<Album> Albums
        {
            get { return albumList.Albums; }
        }
    }
}
