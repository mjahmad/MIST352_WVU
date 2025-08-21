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

namespace Methods
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
            int calculatedValue = 0;

            try
            {
                int leftHandSide = System.Int32.Parse(lhsOperand.Text);
                int rightHandSide = System.Int32.Parse(rhsOperand.Text);

                if (addition.IsChecked.HasValue && addition.IsChecked.Value)
                {
                    calculatedValue = addValues(leftHandSide, rightHandSide);
                    showResult(calculatedValue);
                }
                else if (subtraction.IsChecked.HasValue && subtraction.IsChecked.Value)
                {
                    calculatedValue = subtractValues(leftHandSide, rightHandSide);
                    showResult(calculatedValue);
                }
                else if (multiplication.IsChecked.HasValue && multiplication.IsChecked.Value)
                {
                    calculatedValue = multiplyValues(leftHandSide, rightHandSide);
                    showResult(calculatedValue);
                }
                else if (division.IsChecked.HasValue && division.IsChecked.Value)
                {
                    calculatedValue = divideValues(leftHandSide, rightHandSide);
                    showResult(calculatedValue);
                }
                else if (remainder.IsChecked.HasValue && remainder.IsChecked.Value)
                {
                    calculatedValue = remainderValues(leftHandSide, rightHandSide);
                    showResult(calculatedValue);
                }
            }
            catch (Exception caught)
            {
                expression.Text = "";
                result.Text = caught.Message;
            }
        }

        private int addValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = $"{leftHandSide} + {rightHandSide}";
            return leftHandSide + rightHandSide;
        }

        private int subtractValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = $"{leftHandSide} - {rightHandSide}";
            return leftHandSide - rightHandSide;
        }

        private int multiplyValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = $"{leftHandSide} * {rightHandSide}";
            return leftHandSide * rightHandSide;
        }

        private int divideValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = $"{leftHandSide} / {rightHandSide}";
            return leftHandSide / rightHandSide;
        }

        private int remainderValues(int leftHandSide, int rightHandSide)
        {
            expression.Text = $"{leftHandSide} % {rightHandSide}";
            return leftHandSide % rightHandSide;
        }

        private void showResult(int answer) => result.Text = answer.ToString();
    }
}
