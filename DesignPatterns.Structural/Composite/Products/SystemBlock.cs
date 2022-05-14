using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.Products
{
    public class SystemBlock : IProduct
    {
        public string Category => "System Block";
        public string Name { get; set; }
        public int Article { get; init; }
        public int Price
        {
            get
            {
                const float allowance = 0.15f;
                int totalSum = Case.Price + Motherboard.Price + Processor.Price + RAM.Price + HardDrive.Price + (IncludeGraphicCard is true ? GraphicCard.Price : 0);
                return (int)(totalSum * allowance);
            }
        }

        Case Case { get; set; }
        Motherboard Motherboard { get; set; }
        Processor Processor { get; set; }
        RAM RAM { get; set; }
        HardDrive HardDrive { get; set; }
        GraphicCard GraphicCard { get; set; }

        bool IncludeGraphicCard { get; set; } = true;

        public SystemBlock(string name, int article, Case @case, Motherboard motherboard, Processor processor, RAM rAM, HardDrive hardDrive, GraphicCard graphicCard)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Article = article;
            Case = @case ?? throw new ArgumentNullException(nameof(@case));
            Motherboard = motherboard ?? throw new ArgumentNullException(nameof(motherboard));
            Processor = processor ?? throw new ArgumentNullException(nameof(processor));
            RAM = rAM ?? throw new ArgumentNullException(nameof(rAM));
            HardDrive = hardDrive ?? throw new ArgumentNullException(nameof(hardDrive));
            GraphicCard = graphicCard ?? throw new ArgumentNullException(nameof(graphicCard));
        }

        public override string ToString()
        {
            return $"{Category} : {Name} : Price: {Price} (Article: {Article})" +
                $"\n\t{Case}" +
                $"\n\t{Motherboard}" +
                $"\n\t{RAM}" +
                $"\n\t{HardDrive}" +
                (IncludeGraphicCard is true ? $"\n\t{GraphicCard}\n" : "");
        }
    }
}