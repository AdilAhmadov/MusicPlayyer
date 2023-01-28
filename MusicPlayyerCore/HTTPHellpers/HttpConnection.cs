
using MusicPlayerCore.BussnessEventArgs;
using System;
using System.IO;
using System.Net;

namespace MusicPlayerCore.HTTPHellpers
{
    public class HttpConnection
    {
        private HttpWebRequest Request { get; set; }
        private string postData;
        public string PostData
        {
            get { return postData; }
            set { postData = value; }
        }
        public delegate void HttpResponseCompleteEventHandler(HttpResponseCompleteEventArgs e);
        public event HttpResponseCompleteEventHandler ResponseComplete;
        public event EventHandler<SqueezeErrorEventArgs> OnError;
        private void OnResponseComplete(HttpResponseCompleteEventArgs e)
        {
            if (this.ResponseComplete != null)
            {
                this.ResponseComplete(e);
            }
        }
        public HttpConnection(Uri requestUri, string method, string contentType, string postData)
           : this(requestUri, string.Empty, string.Empty, method, contentType, postData)
        {
        }
        public HttpConnection(Uri requestUri, string username, string password, string method, string contentType, string postData)
        {
            this.postData = postData;
            this.Request = (HttpWebRequest)WebRequest.Create(requestUri);
            this.Request.ContentType = contentType;
            this.Request.Method = method;

            if (!string.IsNullOrEmpty(username))
            {
                this.Request.Credentials = new NetworkCredential(username, password);
            }
        }
        public void ExecuteAsync()
        {
            this.Request.BeginGetRequestStream(new AsyncCallback(BeginRequestAsync), this);
        }
        private void BeginRequestAsync(IAsyncResult ar)
        {
            HttpConnection helper = ar.AsyncState as HttpConnection;
            if (helper != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(helper.PostData))
                    {
                        using (StreamWriter writer = new StreamWriter(helper.Request.EndGetRequestStream(ar)))
                        {
                            writer.Write(helper.PostData);
                        }
                    }

                    helper.Request.BeginGetResponse(new AsyncCallback(BeginResponse), helper);
                }
                catch (Exception ex)
                {
                    SqueezeErrorEventArgs args = null;

                    if (OnError != null)
                    {
                        args = new SqueezeErrorEventArgs(ex);
                        OnError(null, args);
                    }

                    if ((args == null) || (!args.Handled))
                    {
                        throw ex;
                    }
                }
            }
        }

        private void BeginResponse(IAsyncResult ar)
        {
            HttpConnection helper = ar.AsyncState as HttpConnection;
            if (helper != null)
            {
                try
                {
                    HttpWebResponse response = (HttpWebResponse)helper.Request.EndGetResponse(ar);
                    if (response != null)
                    {
                        using (Stream stream = response.GetResponseStream())
                            if (stream != null)
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    helper.OnResponseComplete(new HttpResponseCompleteEventArgs(reader.ReadToEnd()));
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    SqueezeErrorEventArgs args = null;

                    if (OnError != null)
                    {
                        args = new SqueezeErrorEventArgs(ex);
                        OnError(null, args);
                    }

                    if ((args == null) || (!args.Handled))
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
