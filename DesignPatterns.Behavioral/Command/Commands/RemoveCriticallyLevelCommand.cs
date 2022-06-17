using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class RemoveCriticallyLevelCommand : BaseCommand, IUndoCommand
    {
        public RemoveCriticallyLevelCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private CriticallyLevel backupCriticallyLevel;

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

            CriticallyLevel criticallyLevel = bugTrackingSystem.CriticallyLevels.Find(c => c.Id == Int32.Parse(args[0]));
            backupCriticallyLevel = criticallyLevel;

            bugTrackingSystem.CriticallyLevels.Remove(criticallyLevel);
        }

        public void Undo()
        {
            if (backupCriticallyLevel != null)
            {
                bugTrackingSystem.CriticallyLevels.Add(backupCriticallyLevel);
                backupCriticallyLevel = null;
            }
        }
    }
}
