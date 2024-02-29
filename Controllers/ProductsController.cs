using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NetCoreWebApiProject.Models;

namespace ASP.NetCoreWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicaionDbContext _context;
        public ProductsController(ApplicaionDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{ID}")]
        public Product GetByID(int ID)
        {
            return _context.Products.Find(ID);
        }

        [HttpPut("{ID}")]
        public IActionResult UpdateProduct(int ID, Product product)
        {
            try
            {
                if (ID != product.ProductID)
                    return StatusCode(StatusCodes.Status400BadRequest);
                _context.Products.Update(product);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
