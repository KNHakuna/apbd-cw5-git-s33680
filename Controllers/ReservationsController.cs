
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(DateTime? date, string? status, int? roomId)
    {
        List<Reservation> reservations = Data.Reservations;
        if (date.HasValue)
        {
            reservations = reservations.Where(r => r.Date.Date == date.Value.Date).ToList();
        }
        if (!string.IsNullOrEmpty(status))
        {
            reservations = reservations.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        if (roomId.HasValue)
        {
            reservations = reservations.Where(r => r.RoomId == roomId.Value).ToList();
        }
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Reservation? reservation = Data.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        Room? room = Data.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
        if (room == null)
        {
            return NotFound();
        }
        if (room.IsActive == false)
        {
            return Conflict();
        }
        bool conflict = Data.Reservations.Any(r => r.RoomId == reservation.RoomId && r.Date.Date == reservation.Date.Date &&
            ((reservation.StartTime >= r.StartTime && reservation.StartTime < r.EndTime) ||
             (reservation.EndTime > r.StartTime && reservation.EndTime <= r.EndTime)));
        if (conflict) { 
            return Conflict();
        }
        int newId = 1;
        if (Data.Reservations.Count > 0)
        {
            newId = Data.Reservations.Max(r => r.Id) + 1;
        }
        reservation.Id = newId;
        Data.Reservations.Add(reservation);
        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Reservation updatedReservation)
    {
        Reservation? existingReservation = Data.Reservations.FirstOrDefault(r => r.Id == id);
        if (existingReservation == null)
        {
            return NotFound();
        }
        Room? room = Data.Rooms.FirstOrDefault(r => r.Id == updatedReservation.RoomId);
        if (room == null)
        {
            return NotFound();
        }
        if (room.IsActive == false)
        {
            return Conflict();
        }
        bool conflict = Data.Reservations.Any(r => r.Id != id && r.RoomId == updatedReservation.RoomId && r.Date.Date == updatedReservation.Date.Date &&
            ((updatedReservation.StartTime >= r.StartTime && updatedReservation.StartTime < r.EndTime) ||
             (updatedReservation.EndTime > r.StartTime && updatedReservation.EndTime <= r.EndTime)));
        if (conflict)
        {
            return Conflict();
        }
        existingReservation.RoomId = updatedReservation.RoomId;
        existingReservation.OrganizerName = updatedReservation.OrganizerName;
        existingReservation.Topic = updatedReservation.Topic;
        existingReservation.Date = updatedReservation.Date;
        existingReservation.StartTime = updatedReservation.StartTime;
        existingReservation.EndTime = updatedReservation.EndTime;
        existingReservation.Status = updatedReservation.Status;
        return Ok(existingReservation);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Reservation? reservation = Data.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        Data.Reservations.Remove(reservation);
        return NoContent();
    }
}