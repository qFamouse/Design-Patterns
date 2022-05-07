using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Entities
{
    public sealed class Renovation
    {
        /// <summary>
        /// Repair date
        /// </summary>
        public DateTime Date { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Duration in hours
        /// </summary>
        public ushort HoursDuration { get; set; }
        /// <summary>
        /// Cost for repair
        /// </summary>
        public int Cost { get; set; }
    }
}