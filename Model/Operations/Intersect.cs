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
