using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Queries.Contacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllContactsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetContactByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactDto addContactDto)
        {
            var command = _mapper.Map<CreateContactCommand>(addContactDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var command = _mapper.Map<UpdateContactCommand>(updateContactDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
