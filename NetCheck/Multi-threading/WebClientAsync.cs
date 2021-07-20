using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threading
{
    public class WebClientAsync : IWebClientAsync
    {
        public Task<string> DownloadAsync(Uri uri, CancellationToken cancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();

            var webClient = new WebClient();

            using (cancellationToken.Register(() => webClient.CancelAsync()))
            {
                try
                {
                    webClient.DownloadStringCompleted += (sender, args) =>
                    {
                        if (args.Cancelled)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        else if (args.Error != null)
                        {
                            taskCompletionSource.TrySetException(args.Error);
                        }
                        else
                        {
                            taskCompletionSource.TrySetResult(args.Result);
                        }
                    };

                    webClient.DownloadStringAsync(uri);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.TrySetException(ex);
                }

                return taskCompletionSource.Task;
            }
        }
    }
}