using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Factory.Builder;
using DesignPatterns.Creational.Factory.Reader;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests.Creational
{
    internal static class Factory
    {
        private enum FileType
        {
            csv = 1,
            xml = 2
        }

        private static FileType SelectFileType()
        {
            while (true)
            {
                Console.WriteLine("Select file type:");
                Console.WriteLine("1. CSV");
                Console.WriteLine("2. XML");
                switch (Console.ReadKey().KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        return FileType.csv;
                    case "2":
                        Console.Clear();
                        return FileType.xml;
                    default: Console.WriteLine("Unknown type"); break;
                }
            }
        }

        private static void GetResourcesStreamByFileType(FileType fileType, out StreamReader machinesStream, out StreamReader renovationsStream)
        {
            MemoryStream machinesMemoryStream;
            MemoryStream renovationsMemoryStream;

            switch (fileType)
            {
                case FileType.csv:
                    machinesMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.CsvMachines));
                    renovationsMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.CsvRenovations));
                    break;
                case FileType.xml:
                    machinesMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.XmlMachines));
                    renovationsMemoryStream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.XmlRenovations));
                    break;
                default:
                    throw new NotSupportedException("Not support type");
            }

            machinesStream = new StreamReader(machinesMemoryStream);
            renovationsStream = new StreamReader(renovationsMemoryStream);
        }

        private static FactoryReader GetFactoryByFileType(FileType fileType)
        {
            FactoryReader factory = FactorySingleton.GetInstance().FactoryReader;

            switch (fileType)
            {
                case FileType.csv: 
                    factory = new CsvFactoryReader();
                    break;
                case FileType.xml:
                    factory = new XmlFactoryReader();
                    break;
                default:
                    throw new NotSupportedException("Not support type");
            }

            return factory;
        }
        public static void Test()
        {
            FileType fileType = SelectFileType();

            FactoryReader factoryReader = GetFactoryByFileType(fileType);
            EntityBuilder entityBuilder = factoryReader.GetBuilder();

            GetResourcesStreamByFileType(fileType, out StreamReader machinesStream, out StreamReader renovationsStream);

            entityBuilder.ReadMachines(machinesStream);
            entityBuilder.ReadRenovations(renovationsStream);

            var machines = entityBuilder.GetMachines();

            machines.ForEach(m => m.Renovations.Sort((x, y) => DateTime.Compare(x.Date, y.Date)));

            foreach(var machine in machines)
            {
                Console.WriteLine(machine.Name);
                Console.WriteLine($"\tHour productivity: {machine.HourProductivity}");
                Console.WriteLine($"\tPiece Profit: {machine.PieceProfit}");
                foreach(var renovation in machine.Renovations)
                {
                    Console.WriteLine($"\t\t{renovation.Date.ToString("dd.MM.yyyy")} | {renovation.Description} | {renovation.HoursDuration}h | {renovation.Cost}rub");
                }
                Console.WriteLine($"\tProfitability: {machine.CalculateMonthlyIncome(1)}");
            }

            machinesStream.Close();
            renovationsStream.Close();
        }
    }
}