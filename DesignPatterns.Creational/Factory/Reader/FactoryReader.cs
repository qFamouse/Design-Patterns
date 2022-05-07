using DesignPatterns.Creational.Factory.Builder;
using DesignPatterns.Creational.Factory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Reader
{
    public abstract class FactoryReader
    {
        public abstract EntityBuilder GetBuilder();
    }
}