using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class InsertStatusCommand : BaseCommand, IUndoCommand
    {
        public InsertStatusCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Status backupStatus;

        public override void Execute(string[] args)
        {
            if (args[0].Equals("undo"))
            {
                Undo();
            }

            if (args.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            Status status = new Status()
            {
                Name = args[0],
                IsCompleted = Boolean.Parse(args[1])
            };

            backupStatus = status;
            bugTrackingSystem.Statuses.Add(status);
        }

        public void Undo()
        {
            if (backupStatus != null)
            {
                bugTrackingSystem.Statuses.Remove(backupStatus);
                backupStatus = null;
            }
        }
    }
}
