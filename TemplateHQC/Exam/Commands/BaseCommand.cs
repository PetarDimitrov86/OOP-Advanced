using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Interfaces;

namespace Exam.Commands
{
    public abstract class BaseCommand : ICommand
    {
        //Insert the big Class here that holds all the information about the application
        //private IPowerPlant powerPlant;

        //protected BaseCommand(IPowerPlant powerPlant)
        //{
        //    this.PowerPlant = powerPlant;
        //}

        //protected IPowerPlant PowerPlant
        //{
        //    get
        //    {
        //        return this.powerPlant;
        //    }

        //    set
        //    {
        //        this.powerPlant = value;
        //    }
        //}

        public abstract string Execute();
    }
}
