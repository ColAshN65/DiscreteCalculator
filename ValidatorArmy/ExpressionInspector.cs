using System;

namespace DiscreteCalculator.ValidatorArmy
{
    public class ExpressionInspector
    {
        enum ElementType
        {
            Set,
            Operation,
            BackBracket,
            ForwardBracket,
            None
        }
        private ElementType _lastElement = ElementType.None;
        private int _CountBackBrackets = 0;
        private int _CountForwardBrackets = 0;
        public ExpressionInspector(string Expression)
        {
            if (Expression == "") { throw new Exception(); }
            foreach (var element in Expression)
            {
                if (SetValidator.Validate(element))
                {
                    if (_lastElement == ElementType.None || _lastElement == ElementType.BackBracket || _lastElement == ElementType.Operation) { _lastElement = ElementType.Set; }
                    else { throw new Exception(); }
                }
                else if (OperationValidator.Validate(element))
                {
                    if (_lastElement == ElementType.Set || _lastElement == ElementType.ForwardBracket) { _lastElement = ElementType.Operation; }
                    else { throw new Exception(); }
                }
                else if (element == '(')
                {
                    if (_lastElement == ElementType.Operation || _lastElement == ElementType.BackBracket || _lastElement == ElementType.None) { _lastElement = ElementType.BackBracket; _CountBackBrackets++; }
                    else { throw new Exception(); }
                }
                else
                {
                    if (_CountForwardBrackets >= _CountBackBrackets) { throw new Exception(); }

                    if (_lastElement == ElementType.Set || _lastElement == ElementType.ForwardBracket) { _lastElement = ElementType.ForwardBracket; _CountForwardBrackets++; }
                    else { throw new Exception(); }
                }
            }
        }
    }
}
