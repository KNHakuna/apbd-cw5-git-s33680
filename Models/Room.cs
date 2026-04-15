
using System.ComponentModel.DataAnnotations;

public class Room
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string BuildingCode { get; set; }
    public int Floor { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive integer.")]
    public int Capacity { get; set; }
    public Boolean HasProjector { get; set; }
    public Boolean IsActive { get; set; }
}