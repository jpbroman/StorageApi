using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.API.Data;
using StorageApi.API.DTO;
using StorageApi.API.Models;

namespace StorageApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StorageDbContext _context;

    public ProductsController(StorageDbContext context)
    {
        _context = context;
    }

    // GET (all products): api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _context.Products
            .Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Price,
                p.Category,
                p.Shelf,
                p.Count,
                p.Description))
            .ToListAsync();

        return Ok(products);
    }

    // GET (specific product): api/products/2
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Price,
                p.Category,
                p.Shelf,
                p.Count,
                p.Description))
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST (create new product): api/products
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Category = dto.Category,
            Shelf = dto.Shelf,
            Count = dto.Count,
            Description = dto.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = new ProductDto(
            product.Id,
            product.Name,
            product.Price,
            product.Category,
            product.Shelf,
            product.Count,
            product.Description);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            result);
    }

    // PUT (update existing product): api/products/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(
        int id,
        CreateProductDto dto)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Category = dto.Category;
        product.Shelf = dto.Shelf;
        product.Count = dto.Count;
        product.Description = dto.Description;

        await _context.SaveChangesAsync();

        return Ok(new ProductDto(
            product.Id,
            product.Name,
            product.Price,
            product.Category,
            product.Shelf,
            product.Count,
            product.Description));
    }

    // DELETE: api/products/2
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // GET (inventory status): api/products/status
    [HttpGet("status")]
    public async Task<ActionResult<ProductStatusDto>> GetInventoryStatus()
    {
        var numberOfProducts = await _context.Products.CountAsync();
        var totalInventoryValue = await _context.Products.SumAsync(p => p.Price * p.Count);
        var averagePrice = numberOfProducts > 0 ? (int)Math.Round((double)totalInventoryValue / numberOfProducts) : 0;

        return Ok(new ProductStatusDto(numberOfProducts, totalInventoryValue, averagePrice));
    }
}
