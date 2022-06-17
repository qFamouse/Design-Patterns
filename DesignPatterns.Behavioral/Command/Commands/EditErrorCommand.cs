using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    internal class EditErrorCommand : BaseCommand, IUndoCommand
    {
        public EditErrorCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Error backupError;

        public override void Execute(string[] args)
        {
            if (args[0].Equals("undo"))
            {
                Undo();
            }

            if (args.Length < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            var error = bugTrackingSystem.Errors.Find(c => c.Id == Int32.Parse(args[0]));
            backupError = (Error)error.Clone();

            var criticallyLevel = bugTrackingSystem.CriticallyLevels.Find(s => s.Id == Int32.Parse(args[3]));
            var status = bugTrackingSystem.Statuses.Find(s => s.Id == Int32.Parse(args[4]));

            error.Title = args[1];
            error.Description = args[2];
            error.CriticallyLevel = criticallyLevel;
            error.Status = status;
        }

        public void Undo()
        {
            if (backupError != null)
            {
                var @new = bugTrackingSystem.Errors.Find(c => c.Id == backupError.Id);
                @new = backupError;
                backupError = null;
            }
        }
    }
}
