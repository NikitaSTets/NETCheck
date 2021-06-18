using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class WebClientAsync : IWebClientAsync
    {
        private readonly WebClient _webClient;


        public WebClientAsync()
        {
            _webClient = new WebClient();
        }


        public async Task<string> DownloadAsync(Uri uri, CancellationToken cancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            var registration = cancellationToken.Register(() =>
            {
                _webClient.CancelAsync();
                taskCompletionSource.TrySetCanceled();
            });

            try
            {
                _webClient.DownloadStringCompleted += (sender, args) =>
                {
                    registration.Dispose();
                    taskCompletionSource.TrySetResult("Content");
                };

                _webClient.DownloadStringAsync(uri);
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }

            return await taskCompletionSource.Task;
        }
    }
}