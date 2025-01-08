using System;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double num1, num2, result;
        private string operation = string.Empty;
        private void OnOperationClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Content.ToString();
        }

        private void OnEqualsClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput1.Text, out num1) && double.TryParse(txtInput2.Text, out num2))
            {
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            MessageBox.Show("Ошибка: деление на ноль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        MessageBox.Show("Выберите операцию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                }

                txtResult.Text = result.ToString();
            }
            else
                MessageBox.Show("Ошибка: некорректный ввод", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            txtInput1.Clear();
            txtInput2.Clear();
            txtResult.Text = string.Empty;
        }
    }
}
