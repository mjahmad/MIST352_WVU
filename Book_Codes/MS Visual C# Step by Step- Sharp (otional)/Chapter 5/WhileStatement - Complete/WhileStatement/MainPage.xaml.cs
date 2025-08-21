using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WhileStatement
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

        private async void openFileClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            fp.ViewMode = PickerViewMode.List;
            fp.FileTypeFilter.Add("*");

            StorageFile file = await fp.PickSingleFileAsync();
            if (file is not null)
            {
                fileName.Text = file.Path;

                var fileStream = await file.OpenAsync(FileAccessMode.Read);
                var inputStream = fileStream.GetInputStreamAt(0);
                TextReader reader = new StreamReader(inputStream.AsStreamForRead());
                displayData(reader);
            }
        }

        private void displayData(TextReader reader)
        {
            source.Text = "";
            string line = reader.ReadLine();

            while (line is not null)
            {
                source.Text += line + '\n';
                line = reader.ReadLine();
            }

            reader.Dispose();

        }
    }
}
