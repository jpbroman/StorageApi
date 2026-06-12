using System.ComponentModel.DataAnnotations;

namespace StorageApi.API.DTO;

using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Range(0, 1_000_000)]
    public int Price { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Category { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Shelf { get; set; } = string.Empty;

    [Range(0, 100_000)]
    public int Count { get; set; }

    [Required]
    [StringLength(400, MinimumLength = 2)]
    public string Description { get; set; } = string.Empty;
}
