using DesignPatterns.Creational.Factory.Entities;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Builder
{
    public sealed class CsvEntityBuilder : EntityBuilder
    {
        private List<Machine> _machines = new List<Machine>();

        public override List<Machine> GetMachines()
        {
            return _machines;
        }

        public override void ReadMachines(StreamReader stream)
        {
            TextFieldParser parser = new TextFieldParser(stream);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                Machine machine = new Machine();

                machine.Name = fields[0];
                machine.HourProductivity = ushort.Parse(fields[1]);
                machine.PieceProfit = ushort.Parse(fields[2]);
                machine.Renovations = new List<Renovation>();

                _machines.Add(machine);
            }
        }

        public override void ReadRenovations(StreamReader stream)
        {
            TextFieldParser parser = new TextFieldParser(stream);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(";");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                Renovation renovation = new Renovation();

                renovation.Date = DateTime.ParseExact(fields[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                renovation.Description = fields[2];
                renovation.HoursDuration = ushort.Parse(fields[3]);
                renovation.Cost = int.Parse(fields[4]);

                _machines.Find(m => m.Name == fields[0])?.Renovations.Add(renovation);
            }
        }
    }
}