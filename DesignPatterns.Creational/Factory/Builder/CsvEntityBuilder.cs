using DesignPatterns.Creational.Factory.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Builder
{
    public sealed class CsvEntityBuilder : EntityBuilder
    {
        private List<Machine> _machines;
        public CsvEntityBuilder(StreamReader streamReader) : base(streamReader) { }

        public override List<Machine> GetMachines()
        {
            throw new NotImplementedException();
        }

        public override void ReadMachines(StreamReader stream)
        {
            throw new NotImplementedException();
        }

        public override void ReadRenovations(StreamReader stream)
        {
            throw new NotImplementedException();
        }
    }
}
