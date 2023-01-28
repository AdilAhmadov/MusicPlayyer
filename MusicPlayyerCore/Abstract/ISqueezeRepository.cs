using MusicPlayerCore.BussnessEventArgs;
using MusicPlayerCore.EntityModels;
using System;

namespace MusicPlayerCore.Abstract
{
    public interface ISqueezeRepository
    {
        event EventHandler<SqueezeErrorEventArgs> OnError;

        string Password { get; set; }
        string Username { get; set; }

        void GetAlbumsAsync(int count);
        event EventHandler<GetAlbumsCompletedEventArgs> GetAlbumsCompleted;

        void GetArtistsAsync(int count);
        event EventHandler<GetArtistsCompletedEventArgs> GetArtistsCompleted;

        void GetPlayersAsync();
        event EventHandler<GetPlayersCompletedEventArgs> GetPlayersCompleted;

        void GetServerStatusAsync();
        event EventHandler<GetServerStatusCompletedEventArgs> GetServerStatusCompleted;

        void GetSongsFromAlbumAsync(Album album);
        event EventHandler<GetSongsCompletedEventArgs> GetSongsFromAlbumCompleted;
    }
}
