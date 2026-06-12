using System.ComponentModel.DataAnnotations;

namespace StorageApi.API.DTO;

// This is only for GET
public record ProductStatusDto(
    int NumberOfProducts,
    int TotalInventoryValue,
    int AveragePrice)
{
}   