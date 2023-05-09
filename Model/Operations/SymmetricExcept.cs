namespace DiscreteCalculator.Model.Operations
{
    public class SymmetricExcept : DiscreteNumbersOperation
    {
        public SymmetricExcept()
        {
            Priority = 4;
        }

        public override void Calculate(DiscreteElement firstElement, DiscreteElement secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            FirstElement.Body.SymmetricExceptWith(SecondElement.Body);
        }
    }
}
