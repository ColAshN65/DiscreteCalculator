using DiscreteCalculator.Model;
using System.Windows;

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
                MessageBox.Show($"{processor.GetResult().GetBodyInString()}" +
                    $"\nРезультат сохранен в буфер обмена", "Результат:");
                Clipboard.SetText(processor.GetResult().GetBodyInString());
            }
            catch
            {
                MessageBox.Show("Ошибка вычислительного модуля", "Ошибка программного модуля:");
                return;
            }
        }
    }
}
