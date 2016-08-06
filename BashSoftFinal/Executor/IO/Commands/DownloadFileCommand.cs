using Executor.Attributes;
using Executor.Contracts;
using Executor.Exceptions;

namespace Executor.IO.Commands
{
    [Alias("download")]
    public class DownloadFileCommand : Command
    {
        [Inject]
        private IDownloadManager downloadManager;

        public DownloadFileCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string url = this.Data[1];
            this.downloadManager.Download(url);
        }
    }
}
