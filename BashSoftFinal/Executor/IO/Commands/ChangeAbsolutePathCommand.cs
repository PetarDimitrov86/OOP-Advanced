using Executor.Attributes;
using Executor.Contracts;
using Executor.Exceptions;

namespace Executor.IO.Commands
{
    [Alias("cdabs")]
    public class ChangeAbsolutePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}
