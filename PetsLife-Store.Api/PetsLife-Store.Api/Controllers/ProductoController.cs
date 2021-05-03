using AccessData.Queries;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
        public IActionResult Post(ProductoDto producto)
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
        //[ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
        public IActionResult GetProductoById(int id)
        {
            try
            {
               
                return new JsonResult(_service.GetProductoById(id)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("/Productos")]
        //[ProducesResponseType(typeof(Producto), StatusCodes.Status201Created)]
        public IActionResult GetProductos()
        {
            try
            {

                return new JsonResult(_service.GetProductos()) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
