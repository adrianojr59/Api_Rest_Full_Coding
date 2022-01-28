using Api_Rest_Full_Coding.Context;
using Api_Rest_Full_Coding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Rest_Full_Coding.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly appDbContext _context;


        public CategoryController(appDbContext db)
        {
            _context = db;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            try
            {
                return await _context.CategoryList.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }
        }







        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> Getall()
        {
            try
            {
                return await _context.CategoryList.Include(c => c._Product).ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody] Category Category)
        {
            try
            {

                if (Category == null)
                {
                    return BadRequest("Verifique os Dados");
                }

                _context.CategoryList.Add(Category);
                _context.SaveChanges();

                return Ok(Category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }

        }





        [HttpPut("{id:int:min(1)}")]
        public ActionResult put(int id, [FromBody] Category Category)
        {

            try
            {
                if (id != Category.CategoryId)
                {
                    return NotFound("Não Encontrado");
                }

                _context.Entry(Category).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(Category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Servidor Inativo");
            }
        }


        [HttpDelete("{id:int:min(1)}")]
        public ActionResult <Category> Delete (int id)
        {
            var Category = _context.CategoryList.FirstOrDefault(c => c.CategoryId == id);
            if(Category == null)
            {
                return NotFound("Não Encontrado");
            }

            _context.CategoryList.Remove(Category);
            _context.SaveChanges();

            return Ok(Category);
        }


    }
}
