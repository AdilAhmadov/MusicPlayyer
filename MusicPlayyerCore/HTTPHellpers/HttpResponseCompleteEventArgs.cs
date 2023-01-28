namespace MusicPlayerCore.HTTPHellpers
{
    public class HttpResponseCompleteEventArgs
    {
        public string Response { get; set; }
        public HttpResponseCompleteEventArgs(string response)
        {
            this.Response = response;
        }
    }
}
