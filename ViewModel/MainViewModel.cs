using DiscreteCalculator.Base;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using DiscreteCalculator.Model;
using System.Windows;
using DiscreteCalculator.ValidatorArmy;

namespace DiscreteCalculator.ViewModel
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        private string[] _baseElements = new string[5] {"0", "0", "0", "0", "0"};
        public string[] BaseElements
        {
            get { return _baseElements; }
            set
            {
                _baseElements = value;
                OnPropertyChanged();
            }
        }
        private string _expressionText = "";
        public string ExpressionText
        {
            get { return _expressionText; }
            set
            {
                _expressionText = value;
                OnPropertyChanged();
            }
        }
        public ICommand OperationButton
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    ExpressionText += obj.ToString();
                });
            }
        }
        public ICommand ClearAllButton
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    ExpressionText = "";
                    BaseElements = new string[5];
                });
            }
        }
        public ICommand ResultButton
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    BaseSetsConvertor convertor = null;
                    ExpressionInspector inspector;
                    DiscreteProcessor processor;

                    try 
                    { 
                        inspector = new ExpressionInspector(ExpressionText);
                        try
                        {
                            convertor = new BaseSetsConvertor(BaseElements);
                            try
                            {
                                processor = new DiscreteProcessor($"({ExpressionText})", convertor.GetElements());
                                MessageBox.Show(processor.GetResult().GetBodyInString(), "Результат:");
                            }
                            catch { MessageBox.Show("Ошибка вычислительного модуля", "Ошибка программного модуля:"); }
                        }
                        catch { MessageBox.Show("Содержимое множеств введено неверно", "Ошибка введенных данных:"); }
                    }
                    catch { MessageBox.Show("Допущена ошибка в выражении", "Ошибка введенных данных:"); }

                    

                });
            }
        }
    }
}
