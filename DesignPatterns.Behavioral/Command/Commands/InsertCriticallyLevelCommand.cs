using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class InsertCriticallyLevelCommand : BaseCommand, IUndoCommand
    {
        public InsertCriticallyLevelCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        private CriticallyLevel backupCriticallyLevel;

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

            CriticallyLevel criticallyLevel = new CriticallyLevel()
            {
                Name = args[0],
                MaxEliminationTime = new TimeSpan(Int32.Parse(args[1]), Int32.Parse(args[2]), Int32.Parse(args[3]))
            };

            backupCriticallyLevel = criticallyLevel;
            bugTrackingSystem.CriticallyLevels.Add(criticallyLevel);
        }

        public void Undo()
        {
            if (backupCriticallyLevel != null)
            {
                bugTrackingSystem.CriticallyLevels.Remove(backupCriticallyLevel);
                backupCriticallyLevel = null;
            }
        }
    }
}
