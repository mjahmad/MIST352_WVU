namespace HotelReservationSystem;

public class Room
{
    public int Number { get; }
    public string Type { get; }
    public decimal NightlyRate { get; }

    public Room(int number, string type, decimal nightlyRate)
    {
        // TODO: Validate room number, type, and nightly rate.
        // TODO: Assign all three properties.
        throw new System.NotImplementedException();
    }

    public string GetTypeDescription()
    {
        // TODO: REQUIRED STUDENT-WRITTEN SWITCH STATEMENT.
        // "S" => "Standard", "D" => "Deluxe", "F" => "Family".
        // Default => "Unknown".
        throw new System.NotImplementedException();
    }
}
