using Application.Services;
using Domain.DTOs;
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


        [HttpPost]
        [ProducesResponseType(typeof(GenericsCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateCarritoRequestDto carrito)
        {
            try
            {
                return new JsonResult(_service.CreateCarrito(carrito)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
