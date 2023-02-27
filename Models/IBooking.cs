using System;
using System.Collections.Generic;

namespace secondapi.Models;

public partial class IBooking
{
    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int FlightId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public DateTime BookingDate { get; set; }
}
