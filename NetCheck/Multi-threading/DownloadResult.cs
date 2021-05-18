using System;

namespace Multi_threading
{
    public class DownloadResult
    {
        public string Content { get; }

        public bool IsCancelled { get; }

        public Exception Error { get; }


        public DownloadResult(string content, bool isCancelled, Exception error = default)
        {
            IsCancelled = isCancelled;
            Error = error;
            Content = content;
        }
    }
}