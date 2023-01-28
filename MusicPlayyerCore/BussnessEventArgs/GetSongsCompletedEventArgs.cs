
using MusicPlayerCore.EntityModels;
using System;
using System.Collections.Generic;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class GetSongsCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the GetSongsCompletedEventArgs class from the
        /// specified instance of the SongList class
        /// </summary>
        /// <param name="songs">A SongList class that contains the list of songs</param>
        public GetSongsCompletedEventArgs(SongList songs)
        {
            this.songslist = songs;
        }

        private SongList songslist;

        /// <summary>
        /// List of requested songs
        /// </summary>
        public List<Song> Songs
        {
            get { return songslist.Songs; }
        }
    }
}
