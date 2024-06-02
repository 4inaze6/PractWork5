using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersControlElemets
{
    /// <summary>
    /// Логика взаимодействия для GoodsCounter.xaml
    /// </summary>
    public partial class GoodsCounter : UserControl
    {
        public int MaxValue { get; set; }

        public int Value { get; set; }

        public GoodsCounter()
        {
            InitializeComponent();
            Value = 0;
            DigitTextBox.Text = Value.ToString();
            MinusButton.IsEnabled = false;
        }

        public event RoutedEventHandler ValueChanged;

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < MaxValue)
            {
                Value++;
                MinusButton.IsEnabled = true;
                DigitTextBox.Text = Value.ToString();
                ValueChanged?.Invoke(this, new RoutedEventArgs());
                if (Value == MaxValue)
                    PlusButton.IsEnabled = false;
            }
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > 0)
            {
                Value--;
                if (Value == 0)
                    MinusButton.IsEnabled = false;
                if (Value < MaxValue)
                    PlusButton.IsEnabled = true;
                DigitTextBox.Text = Value.ToString();
                ValueChanged?.Invoke(this, new RoutedEventArgs());
            }
        }
    }
}
