using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string str, string value, StringComparison comparison)
        {
            return str.IndexOf(value, comparison) >= 0;
        }
    }




    public static class FileExtensions
    {
        /// <summary>
        /// This is the same default buffer size as
        /// <see cref="StreamReader"/> and <see cref="FileStream"/>.
        /// </summary>
        private const int DefaultBufferSize = 4096;

        /// <summary>
        /// Indicates that
        /// 1. The file is to be used for asynchronous reading.
        /// 2. The file is to be accessed sequentially from beginning to end.
        /// </summary>
        private const FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;

        private static StreamReader AsyncStreamReader(string path)
        {
            FileStream stream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize,
                FileOptions.Asynchronous | FileOptions.SequentialScan);

            return new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
        }

        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken)
        {
            return cancellationToken.IsCancellationRequested
                   ? Task.FromCanceled<string[]>(cancellationToken)
                   : InternalReadAllLinesAsync(path, cancellationToken);
        }
    
        private static async Task<string[]> InternalReadAllLinesAsync(string path, CancellationToken cancellationToken)
        {

            using (StreamReader sr = AsyncStreamReader(path))
            {
                cancellationToken.ThrowIfCancellationRequested();
                string? line;
                List<string> lines = new List<string>();
                while ((line = await sr.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    lines.Add(line);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                return lines.ToArray();
            }
        }

        public static async Task WriteAllTextAsync(string path, string data)
            {
                using (var sw = new StreamWriter(path))
                {
                    await sw.WriteAsync(data);
                }
            }
    }
}
