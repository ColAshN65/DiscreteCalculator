using System.Collections.Generic;

namespace DiscreteCalculator.Model
{
    public class DiscreteElement
    {
        public HashSet<int> Body { get; private set; } = new HashSet<int>();

        public DiscreteElement(HashSet<int> newBody)
        {
            Body = newBody;
        }
        public void AddElement(int element)
        {
            Body.Add(element);
        }
        public void RemoveElement(int element)
        {
            Body.Remove(element);
        }
        public HashSet<int> GetBody() { return Body; }
        public string GetBodyInString()
        {
            string StringBody = "";
            foreach (var item in Body)
            {
                StringBody += $"{item} ";
            }
            return StringBody;
        }
    }
}
