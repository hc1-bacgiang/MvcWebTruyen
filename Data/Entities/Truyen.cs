using System.ComponentModel.DataAnnotations;

namespace MvcWebTruyen.Data.Entities;

public class Truyen
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; }
    public string? Rating { get; set; }
}