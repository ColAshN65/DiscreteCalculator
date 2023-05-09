using System.Collections.Generic;

namespace DiscreteCalculator.Model
{
    public class BaseSetsConvertor
    {
        public List<DiscreteElement> Elements = new List<DiscreteElement>();
        public BaseSetsConvertor(string[] SetsInString)
        {
            foreach (var element in SetsInString)
            {
                SetConvertor convertor = new SetConvertor(element);
                Elements.Add(convertor.GetElement());
            }
        }
        public DiscreteElement[] GetElements() { return Elements.ToArray(); }
    }
}
