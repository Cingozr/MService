using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.Service.Query.List;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.API.Controllers
{

    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllLocation")]
        public async Task<ActionResult<List<string>>> GetAllLocation()
        {
            try
            {
                return await _mediator.Send(new GetAllLocationQuery { });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllNumbersInLocation")]
        public async Task<ActionResult<int>> GetAllNumbersInLocation(string locationName)
        {
            try
            {
                return await _mediator.Send(new GetAllNumbersInLocationQuery { Location = locationName });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllContactsRegisteredToLocation")]
        public async Task<ActionResult<int>> GetAllContactsRegisteredToLocation(string locationName)
        {
            try
            {
                return await _mediator.Send(new GetAllCountOfContactRegisteredToLocationQuery { Location = locationName });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
