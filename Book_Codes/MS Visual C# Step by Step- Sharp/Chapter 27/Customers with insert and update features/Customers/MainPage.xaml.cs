using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace Customers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal const int BatchSize = 100;

        public MainPage()
        {
            this.InitializeComponent();

            List<string> titles = new List<string>
            {
                "Mr.", "Mrs.", "Ms.", "Miss"
            };
            this.title.ItemsSource = titles;
            this.cTitle.ItemsSource = titles;

            ViewModel viewModel = new ViewModel();
            _ = viewModel.GetDataAsync(0, BatchSize);
            this.DataContext = viewModel;
        }
    }
}
