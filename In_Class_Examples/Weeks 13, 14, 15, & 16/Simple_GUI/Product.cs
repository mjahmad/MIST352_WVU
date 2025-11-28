using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    // ===== Fields =====
    private int _id;
    private string _name;
    private double _price;

    // ===== Properties =====
    public int ID
    {
        get { return _id; }
        set
        {
            if (value > 0)
                _id = value;
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
        }
    }

    public double Price
    {
        get { return _price; }
        set
        {
            if (value >= 0)
                _price = value;
        }
    }

    // ===== Constructors =====
    public Product() { }

    public Product(int id, string name, double price)
    {
        ID = id;
        Name = name;
        Price = price;
    }

    // ===== Methods =====
    public string DisplayInfo()
    {
        return $"Product #{ID} - {Name} : ${Price}";
    }
}
