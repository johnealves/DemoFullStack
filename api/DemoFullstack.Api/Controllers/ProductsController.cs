using Microsoft.AspNetCore.Mvc;

namespace DemoFullstack.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
  [HttpGet]
  public IActionResult Get()
  {
    var produtos = new[]
    {
        new { Id = 1, Nome = "Notebook" },
        new { Id = 2, Nome = "Mouse" },
        new { Id = 3, Nome = "Teclado" }
    };

    return Ok(produtos);
  }
}
