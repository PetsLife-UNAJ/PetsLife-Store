using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
        public IActionResult Post(AddProductoDTO producto)
        {
            try
            {
                return new JsonResult(_service.CreateProducto(producto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        public IActionResult GetProductoById(int id)
        {
            try
            {
                return new JsonResult(_service.GetProductoById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/api/Productos")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status200OK)]
        public IActionResult GetProductos([FromQuery] string categoria)
        {
            try
            {

                return new JsonResult(_service.GetProductos(categoria)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status404NotFound)]
        public IActionResult DeleteProducto(int Id)
        {
            try
            {
                if (_service.DeleteProducto(Id))
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

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status404NotFound)]
        public IActionResult PutMercaderia(int Id, AddProductoDTO productoDto)
        {
            try
            {
                if (_service.UpdateProducto(Id, productoDto))
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

        [HttpPut]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status204NoContent)]
        public IActionResult UpdateProductoStock([FromQuery] int idProducto, int newStock)
        {
            try
            {
                return new JsonResult(_service.UpdateProductoStock(idProducto, newStock)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}