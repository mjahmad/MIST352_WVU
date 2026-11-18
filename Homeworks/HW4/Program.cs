using System;
using System.Globalization;
using System.Linq;

namespace HotelReservationSystem;

internal class Program
{
    private static readonly Hotel hotel = new Hotel("Mountaineer Inn");

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== MIST 352 HOTEL RESERVATION SYSTEM =====");
            Console.WriteLine("1. View all rooms");
            Console.WriteLine("2. Find available rooms by dates");
            Console.WriteLine("3. Register a guest");
            Console.WriteLine("4. Create a reservation");
            Console.WriteLine("5. View reservations");
            Console.WriteLine("6. Cancel a reservation");
            Console.WriteLine("7. View active reservation revenue");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            // This menu switch is supplied. Students implement a SECOND switch in Room.cs.
            switch (Console.ReadLine())
            {
                case "1": ShowRooms(); break;
                case "2": ShowAvailableRooms(); break;
                case "3": RegisterGuest(); break;
                case "4": MakeReservation(); break;
                case "5": ShowReservations(); break;
                case "6": CancelReservation(); break;
                case "7": ShowRevenue(); break;
                case "0": return;
                default: Console.WriteLine("Please choose a valid menu number."); break;
            }
        }
    }

    static void ShowRooms()
    {
        Console.WriteLine("\nROOMS");
        foreach (Room room in hotel.Rooms)
            PrintRoom(room);
    }

    static void ShowAvailableRooms()
    {
        DateTime checkIn = ReadDate("Check-in date (yyyy-MM-dd): ");
        DateTime checkOut = ReadDate("Check-out date (yyyy-MM-dd): ");
        try
        {
            Room[] available = hotel.GetAvailableRooms(checkIn, checkOut);
            if (available.Length == 0) Console.WriteLine("No rooms available for those dates.");
            foreach (Room room in available) PrintRoom(room);
        }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
    }

    static void RegisterGuest()
    {
        Console.Write("Guest full name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Guest email: ");
        string email = Console.ReadLine() ?? "";
        try
        {
            Guest guest = hotel.RegisterGuest(name, email);
            Console.WriteLine($"Registered guest #{guest.GuestId}: {guest.FullName}");
        }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
    }

    static void MakeReservation()
    {
        int guestId = ReadInt("Guest ID: ");
        int roomNumber = ReadInt("Room number: ");
        DateTime checkIn = ReadDate("Check-in (yyyy-MM-dd): ");
        DateTime checkOut = ReadDate("Check-out (yyyy-MM-dd): ");
        try
        {
            Reservation reservation = hotel.CreateReservation(guestId, roomNumber, checkIn, checkOut);
            Console.WriteLine($"Reservation #{reservation.ReservationId} created. Total: {reservation.TotalCost:C2}");
        }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
    }

    static void ShowReservations()
    {
        if (hotel.Reservations.Count == 0)
        {
            Console.WriteLine("No reservations yet.");
            return;
        }
        foreach (Reservation r in hotel.Reservations)
        {
            string status = r.IsCanceled ? "Canceled" : "Active";
            Console.WriteLine($"#{r.ReservationId} | {r.Guest.FullName} | Room {r.Room.Number} | " +
                              $"{r.CheckIn:yyyy-MM-dd} to {r.CheckOut:yyyy-MM-dd} | " +
                              $"{r.TotalCost:C2} | {status}");
        }
    }

    static void CancelReservation()
    {
        int id = ReadInt("Reservation ID to cancel: ");
        if (hotel.CancelReservation(id)) Console.WriteLine("Reservation canceled.");
        else Console.WriteLine("Reservation not found or already canceled.");
    }

    static void ShowRevenue()
    {
        Console.WriteLine($"Total value of active reservations: {hotel.CalculateRevenue():C2}");
    }

    static void PrintRoom(Room room)
    {
        Console.WriteLine($"Room {room.Number}: {room.GetTypeDescription()} ({room.Type}) - {room.NightlyRate:C2}/night");
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number)) return number;
            Console.WriteLine("Enter a whole number.");
        }
    }

    static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;
            Console.WriteLine("Use the format yyyy-MM-dd.");
        }
    }
}
