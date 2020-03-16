using AutoMapper;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Queries.Contacts;
using IrmsManagement.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Handlers
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, GetContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdHandler(IContactRepository contactRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetById(request.Id);
            return contact == null ? null : _mapper.Map<GetContactDto>(contact);
        }
    }
}
