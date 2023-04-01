using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.Model.Operations
{
    public abstract class DiscreteNumbersOperation
    {
        public int Priority { get; set; }
        public DiscreteElement FirstElement { get; protected set; }
        public DiscreteElement SecondElement { get; protected set; }
        public abstract void Calculate(DiscreteElement firstElement, DiscreteElement secondElement);
        public DiscreteElement GetResult() { return  this.FirstElement; }

    }
}
