using DesignPatterns.Behavioral.Command;
using DesignPatterns.Behavioral.Command.Commands;
using DesignPatterns.Behavioral.Command.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests.Behavioral
{
    enum CommandName
    {
        View,
        Insert,
        Edit,
        Delete,
        Find
    }

    internal static class Command
    {
        public static Invoker Invoker;
        public static BugTrackingSystem BugTrackingSystem { get; set; }

        private static bool ReadCommand(out string command, out string entity, out string[] args)
        {
            var inputArgs = Console.ReadLine().Split(' ');

            if (inputArgs.Length < 2)
            {
                Console.WriteLine("Incorrect syntax");

                return ReadCommand(out command, out entity, out args);
            }

            command = inputArgs[0];
            entity = inputArgs[1];
            args = inputArgs.Skip(2).ToArray();

            return true;
        }

        public static CommandName? SelectCommand(string command)
        {
            return command.ToLower() switch
            {
                "view" => CommandName.View,
                "insert" => CommandName.Insert,
                "edit" => CommandName.Edit,
                "delete" => CommandName.Delete,
                "find" => CommandName.Find,
                _ => null
            };
        }


        private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        private static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                if (stream.Length > 0)
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return (T)binaryFormatter.Deserialize(stream);
                }
                else
                {
                    return default(T);
                }
            }
        }

        private static void LoadInvoker()
        {
            try
            {
                BugTrackingSystem = ReadFromBinaryFile<BugTrackingSystem>("data");

                if (BugTrackingSystem is not null)
                {
                    Invoker = new Invoker(BugTrackingSystem, Console.WriteLine);
                }
                else
                {
                    BugTrackingSystem = new BugTrackingSystem();
                    Invoker = new Invoker(BugTrackingSystem, Console.WriteLine);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Data not found. A new database has been created");
                BugTrackingSystem = new BugTrackingSystem();
                Invoker = new Invoker(BugTrackingSystem, Console.WriteLine);
            }
        }

        public static void Test()
        {
            LoadInvoker();

            while (true)
            {
                Console.WriteLine("{command} {entity} [agr1, arg2, arg3, ...]");
                ReadCommand(out string command, out string entity, out string[] args);

                CommandName? convertedCommand = SelectCommand(command);

                if (convertedCommand != null)
                {
                    try
                    {
                        switch (convertedCommand.Value)
                        {
                            case CommandName.View:
                                View(entity, args);
                                break;
                            case CommandName.Insert:
                                Insert(entity, args);
                                break;
                            case CommandName.Edit:
                                Edit(entity, args);
                                break;
                            case CommandName.Delete:
                                Delete(entity, args);
                                break;
                            case CommandName.Find:
                                Find(entity, args);
                                break;
                        }

                        WriteToBinaryFile<BugTrackingSystem>("data", BugTrackingSystem);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Unknown command\n");
                }
            }
        }

        private static void View(string entity, string[] args)
        {
            switch (entity.ToLower())
            {
                case "errors": Invoker.ViewErrorsCommand.Execute(args); break;
                case "levels": Invoker.ViewLevelsCommand.Execute(args); break;
                case "statuses": Invoker.ViewStatusesCommand.Execute(args); break;
                default: Console.WriteLine("Unknown entity"); break;
            }
        }

        private static void Insert(string entity, string[] args)
        {
            switch (entity.ToLower())
            {
                case "error": Invoker.InsertErrorCommand.Execute(args); break;
                case "level": Invoker.InsertCriticallyLevelCommand.Execute(args); break;
                case "status": Invoker.InsertStatusCommand.Execute(args); break;
                default: Console.WriteLine("Unknown entity"); break;
            }
        }

        private static void Edit(string entity, string[] args)
        {
            switch (entity.ToLower())
            {
                case "error": Invoker.EditErrorCommand.Execute(args); break;
                case "level": Invoker.EditCriticallyLevelCommand.Execute(args); break;
                case "status": Invoker.EditStatusCommand.Execute(args); break;
                default: Console.WriteLine("Unknown entity"); break;
            }
        }

        private static void Delete(string entity, string[] args)
        {
            switch (entity.ToLower())
            {
                case "error": Invoker.RemoveErrorCommand.Execute(args); break;
                case "level": Invoker.RemoveCriticallyLevelCommand.Execute(args); break;
                case "status": Invoker.RemoveStatusCommand.Execute(args); break;
                default: Console.WriteLine("Unknown entity"); break;
            }
        }

        private static void Find(string entity, string[] args)
        {
            switch (entity.ToLower())
            {
                case "error": Invoker.FindErrorsCommand.Execute(args); break;
                case "level": Invoker.FindLevelsCommand.Execute(args); break;
                case "status": Invoker.FindStatusesCommand.Execute(args); break;
                default: Console.WriteLine("Unknown entity"); break;
            }
        }
    }
}
