namespace DiscreteCalculator.Model.Operations
{
    public class Complement : DiscreteNumbersOperation
    {
        public Complement()
        {
            Priority = 1;
        }

        public override void Calculate(DiscreteElement firstElement, DiscreteElement secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            FirstElement.Body.ExceptWith(SecondElement.Body);
        }
    }
}
