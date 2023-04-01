using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.Model.Operations
{
    public class Union : DiscreteNumbersOperation
    {
        public Union()
        {
            Priority = 2;
        }

        public override void Calculate(DiscreteElement firstElement, DiscreteElement secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            FirstElement.Body.UnionWith(SecondElement.Body);
        }
    }
}
