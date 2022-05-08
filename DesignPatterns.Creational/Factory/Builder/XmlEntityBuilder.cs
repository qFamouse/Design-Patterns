using DesignPatterns.Creational.Factory.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesignPatterns.Creational.Factory.Builder
{
    public sealed class XmlEntityBuilder : EntityBuilder
    {
        private List<Machine> _machines = new List<Machine>();

        public override List<Machine> GetMachines()
        {
            return _machines;
        }

        public override void ReadMachines(StreamReader stream)
        {
            var document = new XmlDocument();
            document.Load(stream);

            XmlNode xmlMachines = document.DocumentElement.SelectSingleNode("/Machines");

            foreach (XmlNode xmlMachine in xmlMachines)
            {
                Machine machine = new Machine();
                foreach (XmlNode xmlNode in xmlMachine.ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case "Name":
                            machine.Name = xmlNode.InnerText;
                            break;

                        case "HourProductivity":
                            machine.HourProductivity = ushort.Parse(xmlNode.InnerText);
                            break;

                        case "PieceProfit":
                            machine.PieceProfit = int.Parse(xmlNode.InnerText);
                            break;

                        default:
                            throw new NotSupportedException("Unknown name");
                    }
                }
                machine.Renovations = new List<Renovation>();
                _machines.Add(machine);
            }
        }

        public override void ReadRenovations(StreamReader stream)
        {
            var document = new XmlDocument();
            document.Load(stream);

            XmlNode xmlRenovations = document.DocumentElement.SelectSingleNode("/Renovations");

            foreach (XmlNode xmlRenovation in xmlRenovations)
            {
                var machineName = xmlRenovation.ChildNodes.Item(0).InnerText;

                _machines.Find(m => m.Name == machineName)?.Renovations.Add(new Renovation()
                {
                    Date = DateTime.ParseExact(xmlRenovation.ChildNodes[1].InnerText, "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    Description = xmlRenovation.ChildNodes[2].InnerText,
                    HoursDuration = ushort.Parse(xmlRenovation.ChildNodes[3].InnerText),
                    Cost = int.Parse(xmlRenovation.ChildNodes[4].InnerText)
                });
            }
        }
    }
}
