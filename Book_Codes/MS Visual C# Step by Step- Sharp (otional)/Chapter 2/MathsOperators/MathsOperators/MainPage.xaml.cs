using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MathsOperators
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void calculateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)addition.IsChecked)
                {
                    addValues();
                }
                else if ((bool)subtraction.IsChecked)
                {
                    subtractValues();
                }
                else if ((bool)multiplication.IsChecked)
                {
                    multiplyValues();
                }
                else if ((bool)division.IsChecked)
                {
                    divideValues();
                }
                else if ((bool)remainder.IsChecked)
                {
                    remainderValues();
                }
            }
            catch (Exception caught)
            {
                expression.Text = "";
                result.Text = caught.Message;
            }
        }

        private void addValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            // TODO: Add rhs to lhs and store the result in outcome
            expression.Text = $"{lhsOperand.Text} + {rhsOperand.Text}";
            result.Text = outcome.ToString();
        }

        private void subtractValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            // TODO: Subtract rhs from lhs and store the result in outcome
            expression.Text = $"{lhsOperand.Text} - {rhsOperand.Text}";
            result.Text = outcome.ToString();
        }

        private void multiplyValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            // TODO: Multiply lhs by rhs and store the result in outcome
            expression.Text = $"{lhsOperand.Text} * {rhsOperand.Text}";
            result.Text = outcome.ToString();
        }

        private void divideValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            // TODO: Divide lhs by rhs and store the result in outcome
            expression.Text = $"{lhsOperand.Text} / {rhsOperand.Text}";
            result.Text = outcome.ToString();
        }

        private void remainderValues()
        {
            int lhs = int.Parse(lhsOperand.Text);
            int rhs = int.Parse(rhsOperand.Text);
            int outcome = 0;
            // TODO: Work out the remainder after dividing lhs by rhs and store the result in outcome
            expression.Text = $"{lhsOperand.Text} % {rhsOperand.Text}";
            result.Text = outcome.ToString();
        }
    }
}
