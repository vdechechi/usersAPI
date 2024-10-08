using BALTACRUD.Data;
using BALTACRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BALTACRUD.Controllers { 


    [Route("products")]
    public class ProductController: ControllerBase
    {


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {

            var products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();

            return Ok(products);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id, [FromServices] DataContext context)
        {
            var product = await context.Products
                                        .AsNoTracking()
                                        .Include(x=> x.Category)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("categories/{id:int}")]

        public async Task<ActionResult<List<Product>>> GetbyCategory(int id, [FromServices] DataContext context)
        {

            var products = await context
                .Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id)
                .ToListAsync();

            return Ok(products);
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Post([FromBody] Product model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    context.Products.Add(model);
                    context.SaveChangesAsync();
                    return Ok(model);

                }
                catch (Exception ex)
                {

                    return BadRequest(new { message = "Erro ao criar Produto" });


                }


            }
        }






    }
}
