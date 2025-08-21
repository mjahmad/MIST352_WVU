using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
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
        private int pixelWidth = 18000;
        private int pixelHeight = 12000;

        private WriteableBitmap graphBitmap = null;
        private int bytesPerPixel = 4;
        private byte[] data;

        private byte redValue, greenValue, blueValue;
        private CancellationTokenSource tokenSource = null;

        public MainPage()
        {
            this.InitializeComponent();

            int dataSize = bytesPerPixel * pixelWidth * pixelHeight;
            data = new byte[dataSize];

            graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }

        private async void plotButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            redValue = (byte)rand.Next(0xFF);
            greenValue = (byte)rand.Next(0xFF);
            blueValue = (byte)rand.Next(0xFF);

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Stopwatch watch = Stopwatch.StartNew();

            try
            {
                // generateGraphData(data, 0, pixelWidth / 2, token);
                await generateGraphDataAsync(data, 0, pixelWidth / 2, token);
                duration.Text = $"Duration (ms): {watch.ElapsedMilliseconds}";
            }

            catch (OperationCanceledException oce)
            {
                duration.Text = oce.Message;
            }

            Stream pixelStream = graphBitmap.PixelBuffer.AsStream();
            pixelStream.Seek(0, SeekOrigin.Begin);
            pixelStream.Write(data, 0, data.Length);
            graphBitmap.Invalidate();
            graphImage.Source = graphBitmap;
        }

        private async Task generateGraphDataAsync(byte[] data,
            int partitionStart, int partitionEnd,
            CancellationToken token)
        {
            Task task = Task.Run(() =>
            generateGraphData(data, partitionStart, partitionEnd, token));
            await task;
        }

        private void generateGraphData(byte[] data, int partitionStart, int partitionEnd, CancellationToken token)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;

            for (int x = partitionStart; x < partitionEnd; x++)
            {
                int s = x * x;
                double p = Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 3)
                {
                    token.ThrowIfCancellationRequested();

                    double r = Math.Sqrt(s + i * i) / a;
                    double q = (r - 1) * Math.Sin(24 * r);
                    double y = i / 3 + (q * c);
                    plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                }
            }
        }

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
