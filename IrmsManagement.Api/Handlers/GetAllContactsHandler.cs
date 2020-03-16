using AutoMapper;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Queries.Contacts;
using IrmsManagement.Data.Repositories.Implementations;
using IrmsManagement.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Handlers
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<GetContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetAllContactsHandler(IContactRepository contactRepository, 
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetContactsAsync();

            var contactResponse = _mapper.Map<IEnumerable<GetContactDto>>(contacts);
            return contactResponse;
        }
    }
}
