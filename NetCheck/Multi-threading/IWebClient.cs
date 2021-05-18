using System;
namespace Multi_threading
{
    public interface IWebClient
    {
        void StartDownload(string url, Action<DownloadResult> onDownloaded);

        void CancelDownload();
    }
}