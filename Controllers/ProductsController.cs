using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;
using System.Collections.Generic;
using System.Linq;

[Route("/products")]
[ApiController]
public class ProductsController : ControllerBase
{

    public ProductsController()
    {
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return ProductService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = ProductService.Get(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        product.Id = ProductService.GetAll().Count + 1;
        ProductService.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Product product)
    {
        var existingProduct = ProductService.Get(product.Id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = ProductService.Get(id);
        if (product == null)
        {
            return NotFound();
        }
        ProductService.Delete(id);
        return NoContent();
    }
}
