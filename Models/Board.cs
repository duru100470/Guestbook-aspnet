using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ducinside.Models;

public class Board
{
    public int Id { get; set; }

    [StringLength(10, MinimumLength = 2)]
    [Required]
    public string Writer { get; set; } = string.Empty;
    
    [StringLength(4)]
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [StringLength(1000)]
    [Required]
    public string Contents { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }

    public int ThumbsUp { get; set; } = 0;
    public int ThumbsDown { get; set; } = 0;
}