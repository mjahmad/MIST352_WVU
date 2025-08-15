using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Drawing
{
    abstract class DrawingShape
    {
        protected int _size;
        protected int _x = 0, _y = 0;
        protected Shape shape = null;

        public DrawingShape(int size)
        {
            this._size = size;
        }

        public void SetLocation(int xCoord, int yCoord)
        {
            this._x = xCoord;
            this._y = yCoord;
        }

        public void SetColor(Color color)
        {
            if(this.shape!=null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                this.shape.Fill = brush;
            }
        }

        public virtual void Draw(Canvas canvas)
        {
            if(this.shape is null)
            {
                throw new InvalidOperationException("Shape is null");
            }

            this.shape.Height = this._size;
            this.shape.Width = this._size;
            Canvas.SetTop(this.shape, this._y);
            Canvas.SetLeft(this.shape, this._x);
            canvas.Children.Add(this.shape);
        }
    }    
}
