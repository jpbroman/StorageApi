using System.ComponentModel.DataAnnotations;

namespace StorageApi.API.DTO;

// This is only for POST
public record CreateProductDto(
    [property: Required]
    [property: StringLength(50, MinimumLength = 2)]
    string Name,

    [property: Range(0, 1_000_000)]
    int Price,

    [property: Required]
    [property: StringLength(50, MinimumLength = 2)]
    string Category,

    [property: Required]
    [property: StringLength(20, MinimumLength = 2)]
    string Shelf,

    [property: Range(0, 100_000)]
    int Count,

    [property: Required]
    [property: StringLength(400, MinimumLength = 2)]
    string Description
);