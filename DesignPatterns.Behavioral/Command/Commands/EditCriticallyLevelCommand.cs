using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    internal class EditCriticallyLevelCommand : BaseCommand, IUndoCommand
    {
        public EditCriticallyLevelCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private CriticallyLevel backupCriticallyLevel;

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

            var criticallyLevel = bugTrackingSystem.CriticallyLevels.Find(c => c.Id == Int32.Parse(args[0]));
            backupCriticallyLevel = (CriticallyLevel) criticallyLevel.Clone();

            criticallyLevel.Name = args[1];
            criticallyLevel.MaxEliminationTime = new TimeSpan(Int32.Parse(args[2]), Int32.Parse(args[3]), Int32.Parse(args[4]));
        }

        public void Undo()
        {
            if (backupCriticallyLevel != null)
            {
                var @new = bugTrackingSystem.CriticallyLevels.Find(c => c.Id == backupCriticallyLevel.Id);
                @new = backupCriticallyLevel;
                backupCriticallyLevel = null;
            }
        }
    }
}
