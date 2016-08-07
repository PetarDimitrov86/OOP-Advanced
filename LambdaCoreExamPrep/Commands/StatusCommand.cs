namespace LambdaCore_Skeleton.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class StatusCommand : Command
    {
        public StatusCommand(string[] input, List<ICore> repository) : base(input, repository)
        {
        }

        public override void Execute()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Lambda Core Power Plant Status:");
            sb.Append(Environment.NewLine);
            sb.Append($"Total Durability: {this.Repository.Sum(x => x.Durability)}");
            sb.Append(Environment.NewLine);
            sb.Append($"Total Cores: {this.Repository.Count}");
            sb.Append(Environment.NewLine);
            sb.Append($"Total Fragments: {this.Repository.Sum(x => x.Fragments.Count())}");
            sb.Append(Environment.NewLine);
            foreach (var core in Repository)
            {
                sb.Append($"Core {core.Name}:");
                sb.Append(Environment.NewLine);
                sb.Append($"####Durability: {core.Durability}");
                sb.Append(Environment.NewLine);
                sb.Append($"####Status: {core.Status()}");
                sb.Append(Environment.NewLine);
            }
            Console.Write(sb.ToString());
        }
    }
}