using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.ValidatorArmy
{
    public static class SetValidator
    {
        public static char[] CharCollection { get; private set; } = new char[5] {'0', '1', '2', '3', '4'};
        public static bool Validate(char element)
        {
            bool result = false;
            foreach (var Symbol in CharCollection)
            {
                if (Symbol == element) { result = true; }
            }
            return result;
        }
    }
}
