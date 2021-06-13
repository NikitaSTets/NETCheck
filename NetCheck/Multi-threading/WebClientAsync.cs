using System;
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


        public async Task<string> DownloadAsync(string url, CancellationToken cancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource<string>(); 
            
            cancellationToken.Register(() =>
            {
                _webClient.CancelDownload();
            });

            var thread = new Thread(() =>
            {
                _webClient.StartDownload(url, result =>
                {
                    if (result.IsCancelled)
                    {
                        Console.WriteLine("Canceled");
                        taskCompletionSource.TrySetCanceled();
                    }

                    if (result.Error != null)
                    {
                        Console.WriteLine("Error");
                        taskCompletionSource.TrySetException(result.Error);
                    }

                    taskCompletionSource.TrySetResult(result.Content);
                });
            });

            thread.Start();

            return await taskCompletionSource.Task;
        }
    }
}