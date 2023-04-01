using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.Model.Operations
{
    public class Intersect : DiscreteNumbersOperation
    {
        public Intersect()
        {
            Priority = 3;
        }

        public override void Calculate(DiscreteElement firstElement, DiscreteElement secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            FirstElement.Body.IntersectWith(SecondElement.Body);
        }
    }
}
