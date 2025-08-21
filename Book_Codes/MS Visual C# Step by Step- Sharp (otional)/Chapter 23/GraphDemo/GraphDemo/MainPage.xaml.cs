using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GraphDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Reduce pixelWidth and pixelHeight if there is insufficient memory available
        private int pixelWidth = 10000;
        private int pixelHeight = 5000;


        private WriteableBitmap graphBitmap = null;
        private int bytesPerPixel = 4;
        private byte[] data;

        private byte redValue, greenValue, blueValue;

        public MainPage()
        {
            this.InitializeComponent();

            // Initialize the array that will hold the graph data
            int dataSize = bytesPerPixel * pixelWidth * pixelHeight;
            data = new byte[dataSize];

            // Initialize the bitmap that will be used to display the graph data
            graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight);
        }

        // Generate the data for the graph and display it
        private void plotButton_Click(object sender, RoutedEventArgs e)
        {
            // Generate random values for the RGB intensity of the graph
            // The graph will appear in a different color each time the user clicks the Plot button
            Random rand = new Random();
            redValue = (byte)rand.Next(0xFF);
            greenValue = (byte)rand.Next(0xFF);
            blueValue = (byte)rand.Next(0xFF);

            // Start a timer
            Stopwatch watch = Stopwatch.StartNew();

            // Generate the data for the graph
            generateGraphData(data);

            // Display the time taken to generate the data
            duration.Text = $"Duration (ms): {watch.ElapsedMilliseconds}";

            // Display the data by using the bitmap
            Stream pixelStream = graphBitmap.PixelBuffer.AsStream();
            pixelStream.Seek(0, SeekOrigin.Begin);
            pixelStream.Write(data, 0, data.Length);
            graphBitmap.Invalidate();
            graphImage.Source = graphBitmap;
            pixelStream.Dispose();
        }

        // Complex function that generates the data for the graph
        private void generateGraphData(byte[] data)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;

            for (int x = 0; x < a; x++)
            {
                int s = x * x;
                double p = Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 3)
                {
                    double r = Math.Sqrt(s + i * i) / a;
                    double q = (r - 1) * Math.Sin(24 * r);
                    double y = i / 3 + (q * c);
                    plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                }
            }
        }

        // Store the data for a given point in the graph in the array
        private void plotXY(byte[] data, int x, int y)
        {
            int pixelIndex = (x + y * pixelWidth) * bytesPerPixel;
            data[pixelIndex] = blueValue;
            data[pixelIndex + 1] = greenValue;
            data[pixelIndex + 2] = redValue;
            data[pixelIndex + 3] = 0xBF;
        }
    }
}
