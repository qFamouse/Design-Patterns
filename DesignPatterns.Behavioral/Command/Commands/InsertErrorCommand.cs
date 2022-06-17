using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class InsertErrorCommand : BaseCommand, IUndoCommand
    {
        public InsertErrorCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Error backupError;

        public override void Execute(string[] args)
        {
            if (args[0].Equals("undo"))
            {
                Undo();
            }

            if (args.Length < 4)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            var criticallyLevel = bugTrackingSystem.CriticallyLevels.Find(s => s.Id == Int32.Parse(args[2]));
            var status = bugTrackingSystem.Statuses.Find(s => s.Id == Int32.Parse(args[3]));

            Error error = new Error()
            {
                Title = args[0],
                Description = args[1],
                Status = status,
                CriticallyLevel = criticallyLevel
            };

            backupError = error;
            bugTrackingSystem.Errors.Add(error);
        }

        public void Undo()
        {
            if (backupError != null)
            {
                bugTrackingSystem.Errors.Remove(backupError);
                backupError = null;
            }
        }
    }
}
