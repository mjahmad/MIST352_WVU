using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


    public class Teller
    {
    private int _id;
    public string _name;
    private string _lastName;

    // ====================Properties=========================
    public int ID
    {
        //Here, we are basically saying once a teller is created, nobody can change their ID. No set.
        //Allow users to view bank ID
        get { return _id; }
    }
    public string Name
    {
        //Here, we can change and view teller name
        //Allow users to view bank ID
        get { return _name; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine($"Name can not be null or empty. Bank name remains {_name}. Try again");

            }
            else
                _name = value;
        }
    }

    
    // ====================Constructors=========================
    // 1. Allow creating teller without providing any info. Set info to default values
    public Teller()
    {
        _id = 111;
        _name = "Not Provided";
       

    }

    // 2. Allow creating teller by providing name only. Set rest to default values
    public Teller(string strName)
    {
        _id = 111;
        _name = strName;

    }

    // 3. Allow creating teller by providing all info
    public Teller(int id, string name)
    {
        _id = id;
        _name = name;
        // Also, extract last name and set _lastName to the extracted last name.
        int pos = _name.LastIndexOf(" ") + 1;
        _lastName = _name.Substring(pos, _name.Length - pos);
    }


    // ====================Methods=========================


    public void DisplayInfo()
    {
        Console.WriteLine($"{_id} == {_name}");
    }

    public void DisplayLastName()
    {
        int pos = _name.LastIndexOf(" ") + 1;
        Console.WriteLine(_name.Substring(pos, _name.Length - pos));

    }


}

