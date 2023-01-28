using MusicPlayerCore.Abstract;
using MusicPlayerCore.BussnessEventArgs;
using MusicPlayerCore.EntityModels;
using MusicPlayerCore.HTTPHellpers;
using System;
using System.Diagnostics;
using System.Reflection;


namespace MusicPlayerCore.Concrete
{
    public class SqueezeRepository : SqueezeBase, ISqueezeRepository
    {
        public event EventHandler<SqueezeErrorEventArgs> OnError;
        public SqueezeRepository() { }
        public string Username { get; set; }
        public string Password { get; set; }

        protected virtual JsonHelper GetJsonHelper()
        {
            JsonHelper helper = new JsonHelper();

            helper.OnError += (e, args) =>
            {
                if (OnError != null)
                {
                    OnError(null, args);
                }
            };

            return helper;
        }

        protected virtual string GetCallerName()
        {
            return new StackTrace().GetFrame(2).GetMethod().Name;
        }

        protected virtual void FireEvent(string eventName, object param)
        {
            // Try to retrieve the specified EventHandler
            FieldInfo eventInfo = this.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);

            // If the EventHandler is found, try to execute it
            if (eventInfo != null)
            {
                var event_member = eventInfo.GetValue(this);

                if (event_member != null)
                {
                    EventArgs eventArgs;

                    // Get the type of the class which is used in the default constructor
                    var type = event_member.GetType().GetMethod("Invoke").GetParameters()[1].ParameterType;
                    // Create an instance of the parameter
                    eventArgs = (EventArgs)Activator.CreateInstance(type, param);
                    // Invoke the EventHandler
                    event_member.GetType().GetMethod("Invoke").Invoke(event_member, new object[] { this, eventArgs });
                }
            }
        }
        protected virtual void Execute<T>(string jsonCommand)
            where T : SqueezeBase
        {
            // Use reflection the get the name of the caller. This name is used to determine te name of the corresponding EventHandler
            string caller = GetCallerName();
            JsonHelper jsonHelper = GetJsonHelper();

            jsonHelper.ResponseComplete += (e) =>
            {
                // Convention over Configuration: each "Get<Name>Async" command has a corresponding "Get<Name>Completed" EventHandler 
                FireEvent(caller.Replace("Async", "Completed"), e.Response);
            };

            // Executes the Async command
            jsonHelper.BeginSendCommandAsync<T>(Username, Password, SqueezeConfig.RemoteUrlJson, jsonCommand);
        }


        public event EventHandler<GetServerStatusCompletedEventArgs> GetServerStatusCompleted;
        public virtual void GetServerStatusAsync()
        {
            Execute<ServerStatus>(SqueezeMessage.CreateMessage(SqueezeCommand.ServerStatus));
        }

        public event EventHandler<GetAlbumsCompletedEventArgs> GetAlbumsCompleted;
        public virtual void GetAlbumsAsync(int count)
        {
            Execute<AlbumList>(SqueezeMessage.CreateMessage(SqueezeCommand.Albums, "0", count.ToString(), SqueezeCommand.AlbumTags));
        }

        public event EventHandler<GetArtistsCompletedEventArgs> GetArtistsCompleted;
        public virtual void GetArtistsAsync(int count)
        {
            Execute<ArtistList>(SqueezeMessage.CreateMessage(SqueezeCommand.Artists, "0", count.ToString()));
        }

        public event EventHandler<GetSongsCompletedEventArgs> GetSongsFromAlbumCompleted;
        public virtual void GetSongsFromAlbumAsync(Album album)
        {
            Execute<SongList>(SqueezeMessage.CreateMessage(SqueezeCommand.Songs, "0", SqueezeCommand.MaxItems, SqueezeCommand.SongTags,
                string.Format(SqueezeCommand.AlbumSelectTag, album.ID)));
        }

        public event EventHandler<GetPlayersCompletedEventArgs> GetPlayersCompleted;
        public virtual void GetPlayersAsync()
        {
            Execute<PlayerList>(SqueezeMessage.CreateMessage(SqueezeCommand.Players, "0", SqueezeCommand.MaxItems));
        }

        public event EventHandler<GetPlayerStatusCompletedEventArgs> GetPlayerStatusCompleted;
        public void GetPlayerStatusAsync(Player player)
        {
            Execute<PlayerStatus>(SqueezeMessage.CreateMessage(player, SqueezeCommand.Status, "-", "1000", SqueezeCommand.SongTags));
        }
    }
}
