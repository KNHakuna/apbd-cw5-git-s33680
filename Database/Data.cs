public class Data
{
    public static List<Room> Rooms { get; set; } = new List<Room>
    {
        new Room
        {
            Id = 1,
            Name = "Conference Room A",
            BuildingCode = "B1",
            Floor = 1,
            Capacity = 10,
            HasProjector = true,
            IsActive = true
        },
        new Room {
            Id = 2,
            Name = "Meeting Room B",
            BuildingCode = "B1",
            Floor = 2,
            Capacity = 5,
            HasProjector = false,
            IsActive = true
        },
        new Room {
            Id = 3,
            Name = "Conference Room C",
            BuildingCode = "B2",
            Floor = 1,
            Capacity = 20,
            HasProjector = true,
            IsActive = true
        },
        new Room{
            Id = 4,
            Name = "Meeting Room D",
            BuildingCode = "B2",
            Floor = 2,
            Capacity = 8,
            HasProjector = false,
            IsActive = true
        },
        new Room
        {
            Id = 5,
            Name = "Conference Room E",
            BuildingCode = "B3",
            Floor= 1,
            Capacity = 15,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 6,
            Name = "Meeting Room F",
            BuildingCode = "B3",
            Floor = 2,
            Capacity = 16,
            HasProjector = false,
            IsActive = true
        }
    };

    public static List<Reservation> Reservations { get; set; } = new List<Reservation>
    {
        new Reservation
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Alice",
            Topic = "Project Kickoff",
            Date = DateTime.Today,
            StartTime = DateTime.Today.AddHours(9),
            EndTime = DateTime.Today.AddHours(10),
            Status = "Confirmed"
        },
        new Reservation
        {
            Id = 2,
            RoomId = 2,
            OrganizerName = "Bob",
            Topic = "Team Meeting",
            Date = DateTime.Today,
            StartTime = DateTime.Today.AddHours(11),
            EndTime = DateTime.Today.AddHours(12),
            Status = "Confirmed"
        },
        new Reservation
        {
            Id = 3,
            RoomId = 3,
            OrganizerName = "Charlie",
            Topic = "Client Presentation",
            Date = DateTime.Today,
            StartTime = DateTime.Today.AddHours(14),
            EndTime = DateTime.Today.AddHours(15),
            Status = "Confirmed"
        },
        new Reservation
        {
            Id = 4,
            RoomId = 4,
            OrganizerName = "David",
            Topic = "Budget Review",
            Date = DateTime.Today,
            StartTime = DateTime.Today.AddHours(16),
            EndTime = DateTime.Today.AddHours(17),
            Status = "Confirmed"
        },
        new Reservation
        {
            Id = 5,
            RoomId = 5,
            OrganizerName = "Eve",
            Topic = "Strategy Meeting",
            Date = DateTime.Today,
            StartTime = DateTime.Today.AddHours(10),
            EndTime = DateTime.Today.AddHours(11),
            Status = "Confirmed"
        }
    };
}