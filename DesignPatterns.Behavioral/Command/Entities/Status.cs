using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Entities
{
    public class Status : ICloneable
    {
        public object Clone() => MemberwiseClone();

        private static int id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Status()
        {
            Id = id++;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | IsCompleted: {IsCompleted}";
        }
    }
}
