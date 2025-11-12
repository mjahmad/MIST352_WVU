using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Bank
{
    // Fields
    private int _id;
    private string _name;
    private string _location;
    public Teller[] _Tellers= new Teller[100];

    // ====================Properties=========================
    public int ID
    {
        //Here, we are basically saying once a bank is created, nobody can change its ID. No set.
        //Allow users to view bank ID
        get { return _id; }
    }
    public string Name
    {
        //Here, we can change and view bank name
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

    public string Location
    {
        get { return _location; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine($"Location can not be null or empty. Bank location remains {_location}. Try again");

            }
            else
                _location = value;
        }


    }


    // ====================Constructors=========================
    // 1. Allow creating bank without providing any info. Set info to default values
    public Bank()
    {
        _id = 999;
        _name = "Not Provided";
        _location = "Not Provided";

    }

    // 2. Allow creating bank by providing name only. Set rest to default values
    public Bank(string strName)
    {
        _id = 999;
        _name = strName;
        _location = "Not Provided";

    }

    // 3. Allow creating bank by providing all info
    public Bank(int intID, string strName, string strLocation)
    {
        _id = intID;
        _name = strName;
        _location = strLocation;

    }


    // ====================Methods=========================
    public void DisplayInfo()
    {
        Console.WriteLine($"Bank ID: {_id}\tName: {_name}\tLocation: {_location}");
    }

    /// <summary>
    /// Adds a teller to the list of tellers for this bank at a certain location in the arrays of the tellers in this class.
    /// </summary>
    /// <param name="tellerData"> The object Teller coming from main</param>
    /// <param name="intIndex"> Were to store the teller in the array of tellers</param>
    public void AddTeller(Teller tellerData, int intIndex)
    {
        // validate index. Cant be 0 or greater than length -1 (99).
        if (intIndex < 0 || intIndex > _Tellers.Length - 1)
            Console.WriteLine($"You are aksing to add a teller to location {intIndex} which is out of bound. Index must be between 0 and {_Tellers.Length - 1}. Try again");
        else if (tellerData.Name.Equals("Not Provided"))
            {
            Console.WriteLine($"You are aksing to add a teller named {tellerData.Name} to this bank? Nope. Try again");


        }
        else

        {
            _Tellers[intIndex] = tellerData;
            Console.WriteLine($"Teller {tellerData.Name} has been added to {_name} in the location {intIndex} =) ");
        }

    }



    public void ListTellers()
    {
        for (int intIndex = 0; intIndex < _Tellers.Length; intIndex++)
        {
            if (_Tellers[intIndex] != null)
            {
                Console.WriteLine($" Teller ID {_Tellers[intIndex].ID} -- Name {_Tellers[intIndex].Name}");
            }
        }

    }



}

