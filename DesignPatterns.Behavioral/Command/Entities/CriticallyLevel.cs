using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Entities
{
    [Serializable]
    public class CriticallyLevel : ICloneable
    {
        public object Clone() => MemberwiseClone();

        private static int id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public TimeSpan MaxEliminationTime { get; set; }

        public CriticallyLevel()
        {
            Id = id++;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | MaxEliminationTime: {MaxEliminationTime}";
        }
    }
}
