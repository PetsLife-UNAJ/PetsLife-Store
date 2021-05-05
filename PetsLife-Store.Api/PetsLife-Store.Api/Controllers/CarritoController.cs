using Application.Services;
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
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _service;
        public CarritoController(ICarritoService service)
        {
            _service = service;
        }

        [HttpPost("{idproducto}, {idcarrito}")]
        [ProducesResponseType(typeof(GenericsCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult AddProductoPedido(int idproducto, int idcarrito)
        {
            try
            {
                return new JsonResult(_service.AddProductoPedido(idproducto, idcarrito)) { StatusCode = 201};
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
                _service.RemoveProductoPedidoFromCarrito(idProductoPedido);
                return new JsonResult(null);
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
