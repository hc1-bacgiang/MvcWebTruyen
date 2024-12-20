namespace MVCMovie.ViewModels;

public class MovieRequest
{
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public IFormFile? Image { get; set; }
}

public class TruyenViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
}