using System;

namespace MusicPlayerCore.Concrete
{
    public class SqueezeConfig
    {
        private SqueezeConfig(string remoteHost, int remotePort)
        {
            this.BigImageSize = 350;
            this.SmallImageSize = 75;

            this.remoteHost = remoteHost;
            this.remotePort = remotePort;
        }

        private static SqueezeConfig config;

        public static SqueezeConfig Instance
        {
            get
            {
                if (config == null)
                {
                    throw new Exception("Configuration not set");
                }

                return config;
            }
        }

        public static void SetConfig(string remoteHost, int remotePort)
        {
            config = new SqueezeConfig(remoteHost, remotePort);
        }

        private string remoteHost;
        public string RemoteHost
        {
            get { return remoteHost; }
        }

        private int remotePort;
        public int RemotePort
        {
            get { return remotePort; }
        }

        public string RemoteUrl
        {
            get
            {
                return string.Format("http://{0}:{1}/", RemoteHost, RemotePort);
            }
        }

        public string RemoteUrlJson
        {
            get
            {
                return string.Format("http://{0}:{1}/jsonrpc.js", RemoteHost, RemotePort);
            }
        }

        public int BigImageSize { get; set; }

        public int SmallImageSize { get; set; }
    }
}
