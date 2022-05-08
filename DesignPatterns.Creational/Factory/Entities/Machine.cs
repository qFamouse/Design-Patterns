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
        public List<Renovation> Renovations { get; set; }

        public int CalculatePotentialIncome()
        {
            const int WorkingHours = 10;
            const int MonthDuration = 25;
            return WorkingHours * MonthDuration * HourProductivity * PieceProfit;
        }

        public int CalculateMonthlyIncome(int month)
        {
            int potentionalIncome = CalculatePotentialIncome();
            int cashExpenses = 0;

            var renovationsPerMonth = Renovations.FindAll(r => r.Date.Month == month);
            foreach (var renovation in renovationsPerMonth)
            {
                int lostProfit = renovation.HoursDuration * HourProductivity * PieceProfit;
                int repairCost = renovation.Cost;
                cashExpenses += lostProfit + repairCost;
            }

            return potentionalIncome - cashExpenses;
        }
    }
}
