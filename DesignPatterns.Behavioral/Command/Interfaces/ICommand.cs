using DesignPatterns.Behavioral.Command.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Interfaces
{
    public interface ICommand
    {
        void Execute(string[] agrs);
    }
}
