using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public string ISBN { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string AuthorName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}