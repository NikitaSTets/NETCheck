using System;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_threading
{
    public interface IWebClientAsync
    {
        Task<string> DownloadAsync(Uri uri, CancellationToken cancellationToken);
    }
}