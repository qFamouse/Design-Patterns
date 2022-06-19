using DesignPatterns.Behavioral.Command.Commands;
using DesignPatterns.Behavioral.Command.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command
{
    public class Invoker
    {
        private BugTrackingSystem BugTrackingSystem { get; set; }
        private Receiver Receiver { get; set; }


        public ViewErrorsCommand ViewErrorsCommand { get; }
        public ViewLevelsCommand ViewLevelsCommand { get; }
        public ViewStatusesCommand ViewStatusesCommand { get; }

        public InsertCriticallyLevelCommand InsertCriticallyLevelCommand { get; }
        public InsertErrorCommand InsertErrorCommand { get; }
        public InsertStatusCommand InsertStatusCommand { get; }

        public EditCriticallyLevelCommand EditCriticallyLevelCommand { get; }
        public EditErrorCommand EditErrorCommand { get; }
        public EditStatusCommand EditStatusCommand { get; }

        public RemoveCriticallyLevelCommand RemoveCriticallyLevelCommand { get; }
        public RemoveErrorCommand RemoveErrorCommand { get; }
        public RemoveStatusCommand RemoveStatusCommand { get; }

        public FindErrorsCommand FindErrorsCommand { get; }
        public FindStatusesCommand FindStatusesCommand { get; }
        public FindLevelsCommand FindLevelsCommand { get; }

        public Invoker(BugTrackingSystem bugTrackingSystem, Receiver receiver)
        {
            BugTrackingSystem = bugTrackingSystem;
            Receiver = receiver;

            ViewLevelsCommand = new ViewLevelsCommand(BugTrackingSystem, Receiver);
            ViewStatusesCommand = new ViewStatusesCommand(BugTrackingSystem, Receiver);
            ViewErrorsCommand = new ViewErrorsCommand(BugTrackingSystem, Receiver);

            InsertCriticallyLevelCommand = new InsertCriticallyLevelCommand(BugTrackingSystem, Receiver);
            InsertErrorCommand = new InsertErrorCommand(BugTrackingSystem, Receiver);
            InsertStatusCommand = new InsertStatusCommand(BugTrackingSystem, Receiver);

            EditCriticallyLevelCommand = new EditCriticallyLevelCommand(BugTrackingSystem, Receiver);
            EditErrorCommand = new EditErrorCommand(BugTrackingSystem, Receiver);
            EditStatusCommand = new EditStatusCommand(BugTrackingSystem, Receiver);

            RemoveCriticallyLevelCommand = new RemoveCriticallyLevelCommand(BugTrackingSystem, Receiver);
            RemoveErrorCommand = new RemoveErrorCommand(BugTrackingSystem, Receiver);
            RemoveStatusCommand = new RemoveStatusCommand(BugTrackingSystem, Receiver);

            FindErrorsCommand = new FindErrorsCommand(BugTrackingSystem, Receiver);
            FindStatusesCommand = new FindStatusesCommand(BugTrackingSystem, Receiver);
            FindLevelsCommand = new FindLevelsCommand(bugTrackingSystem, Receiver);
        }

        public void SetBugTrackingSystem(BugTrackingSystem bugTrackingSystem) => BugTrackingSystem = bugTrackingSystem;
        public void SetReceiver(Receiver receiver) => Receiver = receiver;
    }
}
