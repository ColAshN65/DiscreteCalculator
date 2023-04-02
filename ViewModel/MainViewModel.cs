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
                    ResultValidator.Validate(ExpressionText, BaseElements);
                });
            }
        }
    }
}
