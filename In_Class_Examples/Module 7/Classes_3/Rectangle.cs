/// <summary>
/// Represents a rectangle with a width and height.
/// This class provides a concrete implementation of GetArea.
/// </summary>
public class Rectangle : Shape
{
    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Creates a new Rectangle with the specified width and height.
    /// </summary>
    /// <param name="width">Width of the rectangle.</param>
    /// <param name="height">Height of the rectangle.</param>
    public Rectangle(double width, double height)
        : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Calculates the area of the rectangle (width * height).
    /// </summary>
    /// <returns>The rectangle's area.</returns>
    public override double GetArea()
    {
        return Width * Height;
    }
}