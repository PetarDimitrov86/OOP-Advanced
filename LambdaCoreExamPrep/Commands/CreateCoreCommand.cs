namespace LambdaCore_Skeleton.Commands
{
    using System;
    using Globals;
    using Enums;
    using Factories;
    using System.Collections.Generic;
    using Interfaces;

    public class CreateCoreCommand : Command
    {
        private CoreFactory coreFactory;

        public CreateCoreCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
            this.coreFactory = new CoreFactory();
        }

        public override void Execute()
        {
            ICore currentCore = null;
            if (Input[1] == CoreType.System.ToString())
            {
                currentCore = coreFactory.CreateSystemCore(Input);
            }
            else if (Input[1] == CoreType.Para.ToString())
            {
                currentCore = coreFactory.CreateParaCore(Input);             
            }
            else
            {
                Console.WriteLine("Failed to create Core!");
                return;
            }
            this.Repository.Add(currentCore);
            Console.WriteLine(SuccessMessages.SuccessfullyCreatedCore, (char) (Global.CurrentCoreLetter - 1));
        }
    }
}