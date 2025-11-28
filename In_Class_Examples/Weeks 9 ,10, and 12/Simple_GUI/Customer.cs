using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    // ===== Fields =====
    private int _id;
    private string _name;
    private string _email;

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

    public string Email
    {
        get { return _email; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _email = value;
        }
    }

    // ===== Constructors =====
    public Customer() { }

    public Customer(int id, string name, string email)
    {
        ID = id;
        Name = name;
        Email = email;
    }

    // ===== Methods =====
    public string DisplayInfo()
    {
        return $"Customer #{ID} - {Name} ({Email})";
    }
}
