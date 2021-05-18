﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Multi_threading;

namespace NetCheck
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input");
                var cancellationTokenSource = new CancellationTokenSource();
                var webClientAsync = new WebClientAsync();

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        {
                            try
                            {
                                cancellationTokenSource.CancelAfter(5000);

                                var content = await webClientAsync.DownloadAsync("http://download.xs4all.nl/test/2gb.bin", cancellationTokenSource.Token);
                                Console.WriteLine(content);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            break;
                        }
                    case '2':
                        {
                            try
                            {
                                var content = await webClientAsync.DownloadAsync("http://lololol/failedurl", cancellationTokenSource.Token);
                                Console.WriteLine(content);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            break;
                        }
                    case '3':
                        {
                            var content = await webClientAsync.DownloadAsync("http://mirror.widexs.nl/ftp/pub/speed/1mb.bin", cancellationTokenSource.Token);
                            Console.WriteLine(content);

                            break;
                        }
                }
            }
        }
    }
}