using System.Threading;
using System.Threading.Tasks;

namespace Multi_threading
{
    public interface IWebClientAsync
    {
        Task<string> DownloadAsync(string url, CancellationToken cancellationToken);
    }
}