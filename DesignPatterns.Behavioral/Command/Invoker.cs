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


        public ViewErrorsCommand ViewErrors { get; }
        public ViewLevelsCommand ViewLevels { get; }
        public ViewStatusesCommand ViewStatuses { get; }

        public InsertCriticallyLevelCommand InsertCriticallyLevel { get; }
        public InsertErrorCommand InsertError { get; }
        public InsertStatusCommand InsertStatus { get; }

        public EditCriticallyLevelCommand EditCriticallyLevel { get; }
        public EditErrorCommand EditError { get; }
        public EditStatusCommand EditStatus { get; }

        public RemoveCriticallyLevelCommand RemoveCriticallyLevel { get; }
        public RemoveErrorCommand RemoveError { get; }
        public RemoveStatusCommand RemoveStatus { get; }

        public Invoker(BugTrackingSystem bugTrackingSystem, Receiver receiver)
        {
            BugTrackingSystem = bugTrackingSystem;
            Receiver = receiver;

            ViewLevels = new ViewLevelsCommand(BugTrackingSystem, Receiver);
            ViewStatuses = new ViewStatusesCommand(BugTrackingSystem, Receiver);
            ViewErrors = new ViewErrorsCommand(BugTrackingSystem, Receiver);

            InsertCriticallyLevel = new InsertCriticallyLevelCommand(BugTrackingSystem, Receiver);
            InsertError = new InsertErrorCommand(BugTrackingSystem, Receiver);
            InsertStatus = new InsertStatusCommand(BugTrackingSystem, Receiver);

            EditCriticallyLevel = new EditCriticallyLevelCommand(BugTrackingSystem, Receiver);
            EditError = new EditErrorCommand(BugTrackingSystem, Receiver);
            EditStatus = new EditStatusCommand(BugTrackingSystem, Receiver);

            RemoveCriticallyLevel = new RemoveCriticallyLevelCommand(BugTrackingSystem, Receiver);
            RemoveError = new RemoveErrorCommand(BugTrackingSystem, Receiver);
            RemoveStatus = new RemoveStatusCommand(BugTrackingSystem, Receiver);
        }

        public void SetBugTrackingSystem(BugTrackingSystem bugTrackingSystem) => BugTrackingSystem = bugTrackingSystem;
        public void SetReceiver(Receiver receiver) => Receiver = receiver;
    }
}
