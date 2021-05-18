using System;
using System.Threading;
using Client = System.Net.WebClient;

namespace Multi_threading
{
    public class WebClient : IWebClient
    {
        private readonly Client _webClient;
        private readonly CancellationTokenSource _cancellationTokenSource;


        public WebClient()
        {
            _webClient = new Client();
            _cancellationTokenSource = new CancellationTokenSource();
        }


        public void StartDownload(string url, Action<DownloadResult> onDownloaded)
        {
            try
            {
                _cancellationTokenSource.Token.Register(() =>
                {
                    var canceledDownloadedResult = new DownloadResult("Canceled", true);
                    onDownloaded(canceledDownloadedResult);
                });

                _webClient.DownloadData(url);

                var downloadedResult = new DownloadResult("Content", false);
                onDownloaded(downloadedResult);
            }
            catch (Exception ex)
            {
                var failedDownloadedResult = new DownloadResult("Failed", false, ex);
                onDownloaded(failedDownloadedResult);
            }
        }

        public void CancelDownload()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}