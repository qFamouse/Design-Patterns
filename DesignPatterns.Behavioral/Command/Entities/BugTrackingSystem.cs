using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Entities
{
    public class BugTrackingSystem
    {
        public List<Error> Errors { get; }

        public List<Status> Statuses { get; }

        public List<CriticallyLevel> CriticallyLevels { get; }

        public BugTrackingSystem
            (
            List<Error> errors, 
            List<Status> statuses, 
            List<CriticallyLevel> criticallyLevels
            )
        {
            Errors = errors;
            Statuses = statuses;
            CriticallyLevels = criticallyLevels;
        }

        public BugTrackingSystem() : this
            (
            new List<Error>(), 
            new List<Status>(), 
            new List<CriticallyLevel>()
            ) 
        { }
    }
}
