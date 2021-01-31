using System;
using ExceptionsHandlingInWebAPI.Exceptions;
using ExceptionsHandlingInWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ExceptionsHandlingInWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;
        private readonly IAPIService _service;

        public APIController(ILogger<APIController> logger, IAPIService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("generic")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult SearchGenericException( string firstName = null)
        {
            try
            {
                return Ok(_service.GenericExceptionSearchBy(firstName));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("custom")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult SearchCustomException(string firstName = null)
        {
            try
            {
                return Ok(_service.CustomExceptionSearchBy(firstName));
            }
            catch (MyCustomException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
