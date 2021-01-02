using AutoMapper;
using Contact.API.Models;
using Contact.Data.Entities;
using Contact.Service.Command.Create;
using Contact.Service.Command.Delete;
using Contact.Service.Query.List;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{

    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ContactController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        /// <summary>
        /// Action to create a new contact in the database.
        /// </summary>
        /// <param name="Contacts">Model to create a new Contact</param>
        /// <returns>Returns the created contact</returns>
        /// <response code="200">Returned if the contact was created</response>
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreateContact")]
        public async Task<ActionResult<bool>> CreateContact([FromBody] CreateContactModel model)
        {
            try
            {
                return await _mediator.Send(new CreateContactCommand
                {
                    Contact = _mapper.Map<Contacts>(model)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action to create a new contact information in the database.
        /// </summary>
        /// <param name="ContactInformations">Model to create a new contact Information</param>
        /// <returns>Returns the created contact information</returns>
        /// <response code="200">Returned if the contact Information was created</response>
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreateContactInformation")]
        public async Task<ActionResult<bool>> CreateContactInformation([FromBody] CreateContactInformationModel model)
        {
            try
            {
                return await _mediator.Send(new CreateContactInformationCommand
                {
                    ContactInformation = _mapper.Map<ContactInformations>(model)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to delete  contact  in the database.
        /// </summary>
        /// <param name="Guid contactId">Param to delete contact</param>
        /// <returns>Returns the delete contact</returns>
        /// <response code="200">Returned if the contact Information was deleted</response> 
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteContact")]
        public async Task<ActionResult<bool>> DeleteContact(Guid contactId)
        {
            if (contactId == Guid.Empty)
                return BadRequest($"{new Exception("contactId must not be null")}");

            try
            {

                return await _mediator.Send(new DeleteContactCommand
                {
                    ContactId = contactId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action to delete  contact information  in the database.
        /// </summary>
        /// <param name="Guid contactId">Param to delete contact information</param>
        /// <returns>Returns the delete contact information</returns>
        /// <response code="200">Returned if the contact information was deleted</response> 
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("DeleteContactInformation")]
        public async Task<ActionResult<bool>> DeleteContactInformation(Guid contactInformationId)
        {
            if (contactInformationId == Guid.Empty)
                return BadRequest($"{new Exception("contactId must not be null")}");

            try
            {

                return await _mediator.Send(new DeleteContactInformationCommand
                {
                    ContactId = contactInformationId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action to Get All  contact  in the database.
        /// </summary>
        /// <param name="Guid contactId">Param to Get All contact</param>
        /// <returns>Returns the Get All contact </returns>
        /// <response code="200">Returned if the Get All contact  was deleted</response> 
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllContact")]
        public async Task<ActionResult<List<GetAllContactModel>>> GetAllContact()
        {
            try
            {
                return _mapper.Map<List<GetAllContactModel>>(await _mediator.Send(new GetAllContactQuery { }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Action to Get All  contact information  in the database.
        /// </summary>
        /// <param name="Guid contactId">Param to Get All contact information</param>
        /// <returns>Returns the Get All contact information</returns>
        /// <response code="200">Returned if the Get All contact information was deleted</response> 
        /// <response code="400">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllContactInformation")]
        public async Task<ActionResult<List<GetAllContactInformation>>> GetAllContactInformation()
        {
            try
            {
                return _mapper.Map<List<GetAllContactInformation>>(await _mediator.Send(new GetAllContactInformationQuery { }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
