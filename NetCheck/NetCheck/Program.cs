using System;
using System.Threading;
using System.Threading.Tasks;
using Multi_threading;

namespace NetCheck
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var webClientAsync = new WebClientAsync();
            cancellationTokenSource.CancelAfter(5000);
            var content = await webClientAsync.DownloadAsync(new Uri("https://ftp.byfly.by/test/500Mb"), cancellationTokenSource.Token);

            Console.WriteLine(content.Length);
        }
    }
}