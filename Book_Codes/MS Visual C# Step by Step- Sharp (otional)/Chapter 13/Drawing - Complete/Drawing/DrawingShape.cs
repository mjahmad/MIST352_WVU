using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;


namespace Drawing
{
    class DrawingShape
    {
        protected int size;
        protected int locX = 0, locY = 0;
        protected Shape shape = null;

        public DrawingShape(int size)
        {
            this.size = size;
        }

        public void SetLocation(int xCoord, int yCoord)
        {
            this.locX = xCoord;
            this.locY = yCoord;
        }

        public void SetColor(Color color)
        {
            if (this.shape is not null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                this.shape.Fill = brush;
            }
        }

        public virtual void Draw(Canvas canvas)
        {
            if (this.shape is null)
            {
                throw new InvalidOperationException("Shape is null ");
            }

            this.shape.Height = this.size;
            this.shape.Width = this.size;
            Canvas.SetTop(this.shape, this.locY);
            Canvas.SetLeft(this.shape, this.locX);
            canvas.Children.Add(this.shape);
        }
    }
}
