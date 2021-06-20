using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PetsLife_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _service;
        public CarritoController(ICarritoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetProductoPedidoDTO), StatusCodes.Status201Created)]
        public IActionResult AddProductoPedido([FromQuery] AddProductoPedidoDTO productoPedidoDTO)
        {
            try
            {
                return new JsonResult(_service.AddProductoPedido(productoPedidoDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{idProductoPedido}")]
        [ProducesResponseType(200)]
        public IActionResult RemoveProductoPedidoFromCarrito(int idProductoPedido)
        {
            try
            {
                return new JsonResult(_service.RemoveProductoPedidoFromCarrito(idProductoPedido)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Carrito), StatusCodes.Status200OK)]
        public IActionResult GetCarritoById(int id)
        {
            try
            {
                return new JsonResult(_service.GetCarritoById(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}