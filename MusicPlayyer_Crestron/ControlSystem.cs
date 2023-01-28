using System;
using Crestron.SimplSharp;                          	// For Basic SIMPL# Classes
using Crestron.SimplSharpPro;                       	// For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using Crestron.SimplSharpPro.Diagnostics;		    	// For System Monitor Access
using Crestron.SimplSharpPro.DeviceSupport;             // For Generic Device Support
using VirtualConsoleApp;
using Crestron.SimplSharp.Net;
using Crestron.SimplSharpPro.UI;
using MusicPlayer_Crestron.UI;
using MusicPlayerCore.Concrete;
using MusicPlayerCore.BussnessEventArgs;
using MusicPlayerCore.EntityModels;
using System.Collections.Generic;

namespace MusicPlayer_Crestron
{
    public class ControlSystem : CrestronControlSystem
    {
        public static UIManager UI;
        public XpanelForSmartGraphics myPanel;

        private ServerStatus serverStatus;
        private SqueezeRepository repository;
        private List<Album> albums = null;
        private List<Artist> artists = null;

        public ControlSystem(): base()
        {
            try
            {
                Thread.MaxNumberOfUserThreads = 20;

                CrestronEnvironment.SystemEventHandler += new SystemEventHandler(_ControllerSystemEventHandler);
                CrestronEnvironment.ProgramStatusEventHandler += new ProgramStatusEventHandler(_ControllerProgramEventHandler);
                CrestronEnvironment.EthernetEventHandler += new EthernetEventHandler(_ControllerEthernetEventHandler);
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in the constructor: {0}", e.Message);
            }
        }
        public override void InitializeSystem()
        {
            try
            {
                if (this.SupportsEthernet)
                {
                    myPanel = new XpanelForSmartGraphics(0x2A, this);
                    //myPanel.ExtenderEthernetReservedSigs.Use();
                    UI = new UIManager(myPanel, this);
                    if (InitialParametersClass.ControllerPromptName == "VC-4")
                    {
                        VirtualConsole.Start(45000);
                        this.AddConsoleCommand();
                    }
                   
                }

                
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in InitializeSystem: {0}", e.Message);
            }
        }

        private void repository_GetPlayerStatusCompleted(object sender, GetPlayerStatusCompletedEventArgs e)
        {
            var status = e.PlayerStatus;
            Debug.PrintLine(status.ToString());
        }

        private void repository_GetPlayersCompleted(object sender, GetPlayersCompletedEventArgs e)
        {
            var test = e.Players.Count;
            Debug.PrintLine(test.ToString());
        }

        private void repository_GetSongsFromAlbumCompleted(object sender, GetSongsCompletedEventArgs e)
        {
            foreach (var item in e.Songs)
            {
                Debug.PrintLine($" {item.Album}  {item.ArtworkUrl_Small}");
            }
        }

        private void repository_GetArtistsCompleted(object sender, GetArtistsCompletedEventArgs e)
        {
            artists = e.Artists;
            foreach (var item in artists)
            {
                Debug.PrintLine(item.Name);
            }
        }

        private void repository_GetAlbumsCompleted(object sender, GetAlbumsCompletedEventArgs e)
        {
            albums = e.Albums;
        }

        private void repository_GetServerStatusCompleted(object sender, GetServerStatusCompletedEventArgs e)
        {
            serverStatus = e.ServerStatus;

            repository.GetAlbumsAsync(serverStatus.TotalAlbums);
            repository.GetArtistsAsync(serverStatus.TotalArtists);
            repository.GetPlayersAsync();
        }

        private void repository_OnError(object sender, SqueezeErrorEventArgs e)
        {
            Debug.PrintLine(e.Handled.ToString());
        }

        void _ControllerEthernetEventHandler(EthernetEventArgs ethernetEventArgs)
        {
            switch (ethernetEventArgs.EthernetEventType)
            {//Determine the event type Link Up or Link Down
                case (eEthernetEventType.LinkDown):
                    //Next need to determine which adapter the event is for. 
                    //LAN is the adapter is the port connected to external networks.
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {
                        //
                    }
                    break;
                case (eEthernetEventType.LinkUp):
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {

                    }
                    break;
            }
        }
        void _ControllerProgramEventHandler(eProgramStatusEventType programStatusEventType)
        {
            switch (programStatusEventType)
            {
                case (eProgramStatusEventType.Paused):

                    break;
                case (eProgramStatusEventType.Resumed):

                    break;
                case (eProgramStatusEventType.Stopping):

                    break;
            }

        }
        void _ControllerSystemEventHandler(eSystemEventType systemEventType)
        {
            switch (systemEventType)
            {
                case (eSystemEventType.DiskInserted):
                    //Removable media was detected on the system
                    break;
                case (eSystemEventType.DiskRemoved):
                    //Removable media was detached from the system
                    break;
                case (eSystemEventType.Rebooting):
                    //The system is rebooting. 
                    //Very limited time to preform clean up and save any settings to disk.
                    break;
            }

        }
        private void AddConsoleCommand()
        {
            VirtualConsole.AddNewConsoleCommand(GetUrl, "GetUrl", "Get URl Path From PC");
        }
        private string GetUrl(string CmdParameters)
        {
            SqueezeConfig.SetConfig("172.22.1.100", 9000);
            repository = new SqueezeRepository();
            repository.OnError += new EventHandler<SqueezeErrorEventArgs>(repository_OnError);
            repository.GetServerStatusCompleted += new EventHandler<GetServerStatusCompletedEventArgs>(repository_GetServerStatusCompleted);
            repository.GetAlbumsCompleted += new EventHandler<GetAlbumsCompletedEventArgs>(repository_GetAlbumsCompleted);
            repository.GetArtistsCompleted += new EventHandler<GetArtistsCompletedEventArgs>(repository_GetArtistsCompleted);
            repository.GetSongsFromAlbumCompleted += new EventHandler<GetSongsCompletedEventArgs>(repository_GetSongsFromAlbumCompleted);
            repository.GetPlayersCompleted += new EventHandler<GetPlayersCompletedEventArgs>(repository_GetPlayersCompleted);
            repository.GetPlayerStatusCompleted += new EventHandler<GetPlayerStatusCompletedEventArgs>(repository_GetPlayerStatusCompleted);

            repository.GetServerStatusAsync();
            return CmdParameters;
        }
    }
}