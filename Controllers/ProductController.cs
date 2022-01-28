using Api_Rest_Full_Coding.Context;
using Api_Rest_Full_Coding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Rest_Full_Coding.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly appDbContext _context;


        public ProductController(appDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {

            try
            {
                return await _context.ProductList.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "obterproduto")]
        public async Task<ActionResult<IEnumerable<Product>>> Getsearch(int id)
        {
            try
            {
                var product = await _context.ProductList.AsNoTracking().FirstOrDefaultAsync(c => c.ProductId == id);

                if (product == null)
                {
                    return NotFound("Não Encontrado");
                }

                return Ok(product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");

            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            try
            {

                if (product == null)
                {
                    return BadRequest("Preencha os dados");
                }

                _context.ProductList.Add(product);
                _context.SaveChanges();

                return new CreatedAtRouteResult("obterproduto", new { id = product.ProductId }, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, [FromBody]Product product)
        {

            try { 

            if(id != product.ProductId)
            {
                return NotFound("não encontrado");
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }

        }
        
         [HttpDelete("{id:int:min(1)}")]
         public async Task<ActionResult<IEnumerable<Product>>> Delete (int id)
        {
            var product = await  _context.ProductList.FirstOrDefaultAsync(c => c.ProductId == id);
            if(product == null)
            {
                return NotFound("Não Encontrado");
            }

            _context.ProductList.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }



    }
}
