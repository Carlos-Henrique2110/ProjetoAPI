using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PackingOptimizationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackingController : ControllerBase
    {
        [HttpPost]
        [Route("optimize")]
        public IActionResult OptimizePacking([FromBody] List<Order> orders)
        {
            var response = new List<OptimizedOrder>();

            foreach (var order in orders)
            {
                var optimizedOrder = new OptimizedOrder
                {
                    OrderId = order.OrderId,
                    Boxes = new List<Box>()
                };

                // Lógica simplificada para empacotamento
                foreach (var product in order.Products)
                {
                    var box = optimizedOrder.Boxes.FirstOrDefault(b => b.CanFit(product));

                    if (box == null)
                    {
                        box = new Box();
                        optimizedOrder.Boxes.Add(box);
                    }

                    box.Products.Add(product);
                }

                response.Add(optimizedOrder);
            }

            return Ok(response);
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }

    public class OptimizedOrder
    {
        public int OrderId { get; set; }
        public List<Box> Boxes { get; set; }
    }

    public class Box
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public bool CanFit(Product product)
        {
            // Verifica se o produto cabe na caixa (lógica simplificada)
            return Products.Sum(p => p.Height * p.Width * p.Length) + (product.Height * product.Width * product.Length) <= 96000;
        }
    }
}
