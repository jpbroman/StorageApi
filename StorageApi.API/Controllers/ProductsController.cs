using Microsoft.AspNetCore.Mvc;
using StorageApi.API.Models;

public class ProductsController : ControllerBase
{
    private static List<Product> _products = new List<Product>
    {
        new Product(1, "Product 1", 10, "Category 1", "Shelf A", 100, "Description of Product 1"),
        new Product(2, "Product 2", 20, "Category 2", "Shelf B", 200, "Description of Product 2"),
        new Product(3, "Product 3", 30, "Category 3", "Shelf C", 300, "Description of Product 3")
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Category = updatedProduct.Category;
        product.Shelf = updatedProduct.Shelf;
        product.Count = updatedProduct.Count;
        product.Description = updatedProduct.Description;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        _products.Remove(product);
        return NoContent();
    }
}
