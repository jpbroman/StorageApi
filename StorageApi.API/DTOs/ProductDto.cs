using System.ComponentModel.DataAnnotations;

namespace StorageApi.API.DTO;

// This is only for GET
public record ProductDto(
    int Id,
    string Name,
    int Price,
    string Category,
    string Shelf,
    int Count,
    string Description
)
{
    public int InventoryValue => Price * Count;
}