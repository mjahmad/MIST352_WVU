using System;

/// <summary>
/// Represents an abstract geometric shape.
/// This class defines WHAT all shapes must do (GetArea),
/// but not HOW they calculate it.
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Gets or sets the name of the shape (e.g., "Rectangle", "Circle").
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Initializes a new instance of the Shape class with a given name.
    /// </summary>
    /// <param name="name">The display name of the shape.</param>
    public Shape(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Calculates the area of the shape.
    /// Abstract method: every specific shape MUST implement this.
    /// </summary>
    /// <returns>The area of the shape.</returns>
    public abstract double GetArea();

    /// <summary>
    /// Returns a user-friendly description of the shape and its area.
    /// </summary>
    /// <returns>A string containing the shape's name and area.</returns>
    public virtual string GetDescription()
    {
        return $"{Name} with area = {GetArea():F2}";
    }
}
