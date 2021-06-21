using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLife_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
        public IActionResult Post(AddCategoriaDto categoriaDto)
        {
            try
            {
                return new JsonResult(_service.CreateCategoria(categoriaDto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status404NotFound)]
        public IActionResult DeleteCategoria(int Id)
        {
            try
            {
                if (_service.DeleteCategoria(Id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetCategoriaDto>), StatusCodes.Status200OK)]
        public IActionResult GetCategoriasAll()
        {
            try
            {
                return new JsonResult(_service.GetCategorias()) { StatusCode = 200 };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
