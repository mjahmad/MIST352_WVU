using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using DataTypes;

namespace DeliveryService
{
    public class Shipper
    {
        public delegate void ShippingCompleteDelegate(string message);
        public event ShippingCompleteDelegate ShipProcessingComplete;

        public void ShipOrder(Order order)
        {
            this.doShipping(order);
        }

        private async void doShipping(Order order)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync($"dispatch-{order.OrderID}.txt");
                if (file != null)
                {
                    string dispatchNote = $"Order Summary: \r\nOrder ID: {order.OrderID}\r\nOrder Total: {order.TotalValue:C}";

                    var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                    var writeStream = stream.GetOutputStreamAt(0);
                    DataWriter writer = new DataWriter(writeStream);
                    writer.WriteString(dispatchNote);
                    await writer.StoreAsync();
                    await writeStream.FlushAsync();
                    writeStream.Dispose();
                }
                else
                {
                    MessageDialog dlg = new MessageDialog($"Unable to save to file: {file.DisplayName}", "Not saved");
                    _ = dlg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                _ = dlg.ShowAsync();
            }
            finally
            {
                if (this.ShipProcessingComplete is not null)
                {
                    this.ShipProcessingComplete($"Dispatch note generated for Order {order.OrderID}");
                }
            }
        }
    }
}
