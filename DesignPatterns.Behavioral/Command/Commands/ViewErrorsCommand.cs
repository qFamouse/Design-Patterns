using DesignPatterns.Behavioral.Command.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public class ViewErrorsCommand : BaseCommand
    {
        public ViewErrorsCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
            : base(bugTrackingSystem, receiver) { }

        public override void Execute(string[] args)
        {
            var view = new StringBuilder();

            bugTrackingSystem.Errors.ForEach(error =>
            {
                view.AppendLine(error.ToString()).AppendLine();
            });

            if (view.Length > 0)
            {
                receiver(view.ToString());
            }
            else
            {
                receiver("No data available");
            }
        }
    }
}
