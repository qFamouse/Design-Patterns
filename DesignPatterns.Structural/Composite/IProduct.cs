using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    public interface IProduct
    {
        String Category { get; }
        String Name { get; }
        int Article { get; }
        int Price { get; }
    }
}