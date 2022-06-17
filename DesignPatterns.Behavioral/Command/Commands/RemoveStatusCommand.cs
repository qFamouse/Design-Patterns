using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class RemoveStatusCommand : BaseCommand, IUndoCommand
    {
        public RemoveStatusCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Status backupStatus;

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

            Status status = bugTrackingSystem.Statuses.Find(c => c.Id == Int32.Parse(args[0]));
            backupStatus = status;

            bugTrackingSystem.Statuses.Remove(status);
        }

        public void Undo()
        {
            if (backupStatus != null)
            {
                bugTrackingSystem.Statuses.Add(backupStatus);
                backupStatus = null;
            }
        }
    }
}
