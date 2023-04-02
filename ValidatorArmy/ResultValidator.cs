using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DiscreteCalculator.Model;

namespace DiscreteCalculator.ValidatorArmy
{
    public static class ResultValidator
    {
        public static void Validate(string ExpressionText, string[] BaseElements)
        {
            BaseSetsConvertor convertor = null;
            ExpressionInspector inspector;
            DiscreteProcessor processor;
            try
            {
                inspector = new ExpressionInspector(ExpressionText);
            }
            catch
            {
                MessageBox.Show("Допущена ошибка в выражении", "Ошибка введенных данных:");
                return;
            }

            try
            {
                convertor = new BaseSetsConvertor(BaseElements);
            }
            catch
            {
                MessageBox.Show("Ошибка вычислительного модуля", "Ошибка программного модуля:");
                return;
            }

            try
            {
                processor = new DiscreteProcessor($"({ExpressionText})", convertor.GetElements());
                MessageBox.Show(processor.GetResult().GetBodyInString(), "Результат:");
            }
            catch
            {
                MessageBox.Show("Ошибка вычислительного модуля", "Ошибка программного модуля:");
                return;
            }
        }
    }
}
