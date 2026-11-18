using System;
using System.Collections.Generic;

namespace HotelReservationSystem;

public class Hotel
{
    public string Name { get; }

    // REQUIRED ARRAY: exactly five predefined rooms. Do not change to List<Room>.
    private readonly Room[] rooms = new Room[5];
    private readonly List<Guest> guests = new List<Guest>();
    private readonly List<Reservation> reservations = new List<Reservation>();
    private int nextGuestId = 1;
    private int nextReservationId = 1;

    public Room[] Rooms => rooms;
    public IReadOnlyList<Reservation> Reservations => reservations.AsReadOnly();

    public Hotel(string name)
    {
        // TODO: Assign Name and initialize rooms[0] through rooms[4].
        // Room(101, "S", 90m), Room(102, "S", 90m), Room(201, "D", 140m),
        // Room(202, "D", 140m), Room(301, "F", 190m).
        throw new NotImplementedException();
    }

    public Guest RegisterGuest(string fullName, string email)
    {
        // TODO: Create Guest with nextGuestId, append to guests, increment ID, return Guest.
        throw new NotImplementedException();
    }

    public Room[] GetAvailableRooms(DateTime checkIn, DateTime checkOut)
    {
        // TODO: Validate dates. Loop over rooms array and reservations list.
        // TODO: Return an ARRAY containing every room with no overlapping active stay.
        throw new NotImplementedException();
    }

    public Reservation CreateReservation(int guestId, int roomNumber, DateTime checkIn, DateTime checkOut)
    {
        // TODO: Validate dates, find existing guest and room; reject missing records.
        // TODO: Reject overlapping active reservations for the same room.
        // TODO: Create Reservation, add to list, increment ID, return it.
        throw new NotImplementedException();
    }

    public bool CancelReservation(int reservationId)
    {
        // TODO: Return false when not found or already canceled.
        // Otherwise cancel and return true.
        throw new NotImplementedException();
    }

    public decimal CalculateRevenue()
    {
        // TODO: Sum TotalCost for NON-CANCELED reservations only.
        throw new NotImplementedException();
    }
}
