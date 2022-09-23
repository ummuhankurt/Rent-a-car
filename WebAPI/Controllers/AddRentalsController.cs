using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRentalsController : ControllerBase
    {
        IAddRentalDtoService _addRentalDtoService;

        public AddRentalsController(IAddRentalDtoService addRentalDtoService)
        {
            _addRentalDtoService = addRentalDtoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _addRentalDtoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddRentalDto addRentalDto)
        {
            var result = _addRentalDtoService.Add(addRentalDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
