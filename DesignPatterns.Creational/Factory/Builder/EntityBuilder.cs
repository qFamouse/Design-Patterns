using DesignPatterns.Creational.Factory.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Builder
{
    public abstract class EntityBuilder
    {
        public abstract void ReadMachines(StreamReader stream);
        public abstract void ReadRenovations(StreamReader stream);
        public abstract List<Machine> GetMachines();
    }
}
