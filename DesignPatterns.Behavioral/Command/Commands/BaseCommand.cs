using DesignPatterns.Behavioral.Command.Entities;
using DesignPatterns.Behavioral.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Commands
{
    public delegate void Receiver(object? value);

    public abstract class BaseCommand : ICommand
    {
        private protected BugTrackingSystem bugTrackingSystem;
        private protected Receiver receiver;

        abstract public void Execute(string[] args);

        protected BaseCommand(BugTrackingSystem bugTrackingSystem, Receiver receiver)
        {
            this.bugTrackingSystem = bugTrackingSystem ?? throw new ArgumentNullException(nameof(bugTrackingSystem));
            this.receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        }
    }
}
