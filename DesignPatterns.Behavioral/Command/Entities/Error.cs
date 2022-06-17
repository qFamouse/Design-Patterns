using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Entities
{
    public class Error : ICloneable
    {
        public object Clone() => MemberwiseClone();

        private static int id = 1;
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CriticallyLevel CriticallyLevel { get; set; }
        public Status Status { get; set; }

        public Error()
        {
            Id = id++;
        }

        public override string ToString()
        {
            return $"Id: {Id}" +
                $"\nTitle {Title}" +
                $"\nDescription {Description}" +
                $"\nCriticallyLevel: {CriticallyLevel}" +
                $"\nStatus: {Status}";
        }
    }
}
