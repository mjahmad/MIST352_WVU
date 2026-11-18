using System;

namespace HotelReservationSystem;

public class Reservation
{
    public int ReservationId { get; }
    public Guest Guest { get; }
    public Room Room { get; }
    public DateTime CheckIn { get; }
    public DateTime CheckOut { get; }
    public bool IsCanceled { get; private set; }
    public int Nights => (CheckOut - CheckIn).Days;
    public decimal TotalCost => Nights * Room.NightlyRate;

    public Reservation(int reservationId, Guest guest, Room room, DateTime checkIn, DateTime checkOut)
    {
        // TODO: Validate ID, guest, room, and dates (checkout > checkin).
        // TODO: Assign properties; default IsCanceled to false.
        throw new NotImplementedException();
    }

    public bool Overlaps(DateTime requestedCheckIn, DateTime requestedCheckOut)
    {
        // TODO: A canceled reservation never blocks a room.
        // TODO: Overlap when requestedCheckIn < CheckOut AND requestedCheckOut > CheckIn.
        // Back-to-back stays (checkout = next checkin) do NOT overlap.
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        // TODO: Set IsCanceled to true.
        throw new NotImplementedException();
    }
}
