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
        public ICommand AppInfoButton
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    MessageBox.Show("Элементы управления:" +
                        "\n  -В верхней части окна расположена строка выражения множеств." +
                        "\n  -В левой части окна расположена таблица множеств. В первой колонке расположены кнопки с условным обозначением множества." +
                        "Во второй колонке расположены строки с содержимым множеств, куда нужно ввести элементы множеств." +
                        "По умолчанию все множества имееют значение 0." +
                        "\nВАЖНО! Внутри множеств должны быть только целые числа, между которыми может быть пробел, запятая или пробел после запятой." +
                        "\n  -В правой части окна расположены все кнопки операций над множествами с условным обозначением, а также кнопки скобок и кнопка" +
                        "результирования и отчистки, которая отчищает строку выражения и содержимое множеств." +
                        "\nРезультат:" +
                        "\n  -Результат выводится в отдельном окне и копируется в буфер обмена для удобства работы с ним." +
                        "\n  -В случае если в написании выражения или написании тела множесва была допущена ошибка будет выведено окно с соотвтетствующим предупреждением.",
                        "Как это работает?");
                });
            }
        }
    }
}
