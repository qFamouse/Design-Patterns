using DesignPatterns.Behavioral.Command.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class FindErrorsCommand : BaseCommand
    {
        public FindErrorsCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        public override void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            var error = bugTrackingSystem.Errors.Find(e => e.Id == Int32.Parse(args[0]));

            receiver(error.ToString());
        }
    }
}
