using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Entities
{
    public sealed class Machine
    {
        public string Name { get; set; }
        /// <summary>
        /// Number of parts per hour
        /// </summary>
        public ushort HourProductivity { get; set; }
        /// <summary>
        /// Profit from one part
        /// </summary>
        public int PieceProfit { get; set; }
        /// <summary>
        /// Repair works
        /// </summary>
        List<Renovation> Renovations { get; set; }
    }
}
