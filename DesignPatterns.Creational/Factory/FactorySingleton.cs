using DesignPatterns.Creational.Factory.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public class FactorySingleton
    {
        private static FactorySingleton instance = new FactorySingleton();

        public FactoryReader FactoryReader { get; }

        private protected FactorySingleton() { }

        public static FactorySingleton GetInstance()
        {
            return instance;
        }
    }
}