using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class EditStatusCommand : BaseCommand, IUndoCommand
    {
        public EditStatusCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private Status backupStatus;

        public override void Execute(string[] args)
        {
            if (args[0].Equals("undo"))
            {
                Undo();
            }

            if (args.Length < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(args), "Not enough parameters");
            }

            var status = bugTrackingSystem.Statuses.Find(c => c.Id == Int32.Parse(args[0]));
            backupStatus = (Status)status.Clone();

            status.Name = args[1];
            status.IsCompleted = Boolean.Parse(args[2]);
        }

        public void Undo()
        {
            if (backupStatus != null)
            {
                var @new = bugTrackingSystem.Statuses.Find(c => c.Id == backupStatus.Id);
                @new = backupStatus;
                backupStatus = null;
            }
        }
    }
}
