using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public enum CaseType
    {
        FullTower,
        Tower,
        MiniTower,
        Desktop
    }

    public class Case : BaseProduct
    {
        public override string Category => "Case";
        public int PowerSupply { get; set; }
        public CaseType CaseType { get; set; }

        public Case(string name, int article, int price, int powerSupply, CaseType caseType) : base(name, article, price)
        {
            PowerSupply = powerSupply;
            CaseType = caseType;
        }

        public override string ToString()
        {
            return base.ToString() + $"PowerSupply: {PowerSupply} | CaseType: {CaseType}";
        }
    }
}
