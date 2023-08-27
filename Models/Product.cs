using System;
namespace Entertainment_Guild.Models;

public class Product
{
    public int ID { get; set; }
    public string? Name { get; set; }   
    public string? Author { get; set; }
    public string? Description { get; set; }
    public int Genre { get; set; }
    public int subGenres { get; set; }
    public DateTime Published { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime LastUpdated { get; set; }
}
