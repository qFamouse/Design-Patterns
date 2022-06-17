using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class RemoveErrorCommand : BaseCommand, IUndoCommand
    {
        public RemoveErrorCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Error backupError;

        public override void Execute(string[] args)
        {
            if (args[0].Equals("undo"))
            {
                Undo();
            }

            if (args.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            Error error = bugTrackingSystem.Errors.Find(c => c.Id == Int32.Parse(args[0]));
            backupError = error;

            bugTrackingSystem.Errors.Remove(error);
        }

        public void Undo()
        {
            if (backupError != null)
            {
                bugTrackingSystem.Errors.Add(backupError);
                backupError = null;
            }
        }
    }
}
