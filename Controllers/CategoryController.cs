﻿using BALTACRUD.Data;
using BALTACRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BALTACRUD.Controllers
{

    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {

            var categories = await context.Categories.AsNoTracking().ToListAsync();

            return Ok(categories);

            


        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id, [FromServices] DataContext context)
        {
            var category = await context.Categories
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Post([FromBody] Category model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    context.Categories.Add(model);
                    context.SaveChangesAsync();
                    return Ok(model);

                }
                catch (Exception ex)
                {

                    return BadRequest(new { message = "Erro ao criar Categoria" });


                }


            }
        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                try
                {
                    context.Entry<Category>(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return Ok(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest(new { message = "Erro ao atualizar categoria" });
                }
            }

        }



        [HttpDelete]
        [Route("{id:int}")]

        public async Task<ActionResult<List<Category>>> Delete(int id, [FromServices] DataContext context) {

            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Categoria Deletada com sucesso" });
            

        
        }








        }
}
