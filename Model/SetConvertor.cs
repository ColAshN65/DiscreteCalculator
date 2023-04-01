using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.Model
{
    public class SetConvertor
    {
        public DiscreteElement Element { get; private set; }
        public SetConvertor(string strElement)
        {
            HashSet<int> Body = new HashSet<int>();
            string Value = "";

            foreach (char element in strElement)
            {
                if((element == ' ' || element == ',') && Value != "") 
                {
                    Body.Add(int.Parse(Value));
                    Value = "";
                }
                else { Value += element; }
            }

            if (Value != "") { Body.Add(int.Parse(Value)); }
            Element = new DiscreteElement(Body);
        }
        public DiscreteElement GetElement() { return Element; }
        

    }
}
