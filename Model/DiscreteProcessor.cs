using DiscreteCalculator.Model.Operations;
using DiscreteCalculator.ValidatorArmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DiscreteCalculator.Model
{
    public class DiscreteProcessor
    {
        public DiscreteElement[] MainElements { get; private set; }
        Stack<DiscreteElement> StackElements { get; set; } = new Stack<DiscreteElement>();
        Stack<DiscreteNumbersOperation> StackOperations { get; set; } = new Stack<DiscreteNumbersOperation>();

        public DiscreteProcessor(string expression, DiscreteElement[] mainElements)
        {
            MainElements = mainElements;

            foreach (var element in expression)
            {
                if (OperationValidator.Validate(element))
                {
                    if (StackOperations.Count > 1)
                    {
                        DiscreteNumbersOperation secondOperation = OperartionDefine(element);
                        if (StackOperations.Peek().Priority > secondOperation.Priority) { Calculating(); }
                        StackOperations.Push(secondOperation);
                    }
                    else { StackOperations.Push(OperartionDefine(element)); }
                }
                else if (element == '(') { StackOperations.Push(new BackBracket()); }
                else if (element == ')') { ForwardBracketDetected(); }
                else
                {
                    StackElements.Push(MainElements[int.Parse($"{element}")]);
                }
            }
        }
        private void ForwardBracketDetected()
        {
            while(StackOperations.Peek().GetType() != new BackBracket().GetType())
            {
                Calculating();
            }
            StackOperations.Pop();
        }
        private void Calculating()
        {
            DiscreteNumbersOperation operation = StackOperations.Pop();
            DiscreteElement secondElement = StackElements.Pop();
            DiscreteElement firstElement = StackElements.Pop();

            operation.Calculate(firstElement, secondElement);

            StackElements.Push(operation.GetResult());
        }
        private DiscreteNumbersOperation OperartionDefine(char element)
        {
            switch(element)
            {
                case 'U':
                    {
                        return new Union();
                    }break;
                case '/':
                    {
                        return new Complement();
                    }break;
                case 'X':
                    {
                        return new Intersect();
                    }
                    break;
                case 'C':
                    {
                        return new SymmetricExcept();
                    }
                    break;
                default: { return null; }
            }
        }
        public DiscreteElement GetResult() { return StackElements.Peek(); }

    }
}
