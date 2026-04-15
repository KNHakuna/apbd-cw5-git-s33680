
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase {
    [HttpGet]
    public IActionResult GetAll(int? minCapacity, bool? hasProjector, bool? activeOnly)
    {
        List<Room> rooms = Data.Rooms;
        if (minCapacity.HasValue)
        {
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value).ToList();
        }
        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value).ToList();
        }
        if (activeOnly.HasValue)
        {
            rooms = rooms.Where(r => r.IsActive == activeOnly.Value).ToList();
        }
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Room? room = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuilding(string buildingCode)
    {
        List<Room> rooms = Data.Rooms.Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase)).ToList();
        return Ok(rooms);
    }
    [HttpPost]
    public IActionResult Create(Room newRoom)
    {
        int newId = 1;
        if (Data.Rooms.Count > 0) {
            newId = Data.Rooms.Max(r => r.Id) + 1;
        }
        newRoom.Id=newId;
        Data.Rooms.Add(newRoom);
        return CreatedAtAction(nameof(GetById), new { id = newRoom.Id }, newRoom);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Room updatedRoom)
    {
        Room? existingRoom = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if (existingRoom == null)
        {
            return NotFound();
        }
        existingRoom.Name = updatedRoom.Name;
        existingRoom.BuildingCode = updatedRoom.BuildingCode;
        existingRoom.Floor = updatedRoom.Floor;
        existingRoom.Capacity = updatedRoom.Capacity;
        existingRoom.HasProjector = updatedRoom.HasProjector;
        existingRoom.IsActive = updatedRoom.IsActive;
        return Ok(existingRoom);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) { 
        Room? room = Data.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
        {
            return NotFound();
        }
        bool hasReservations = Data.Reservations.Any(r => r.RoomId == id);
        if (hasReservations) {
            return Conflict();
        }
        Data.Rooms.Remove(room);
        return NoContent();
    }
}