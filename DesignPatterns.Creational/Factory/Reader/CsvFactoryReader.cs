﻿using DesignPatterns.Creational.Factory.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Reader
{
    public sealed class CsvFactoryReader : FactoryReader
    {
        public override EntityBuilder GetBuilder()
        {
            return new CsvEntityBuilder();
        }
    }
}