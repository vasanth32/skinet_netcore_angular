using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            List<Products> Prod = await _context.Products.ToListAsync();
            return Ok(Prod);
        }

        [HttpGet("{_id}")]
        public async Task<ActionResult<Products>> GetProduct(int _id)
        {

            return await _context.Products.FindAsync(_id);
        }


    }
}