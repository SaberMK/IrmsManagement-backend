using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Data.Repositories.Interfaces;
using IrmsManagement.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Handlers
{
    public class CreateContractHandler : IRequestHandler<CreateContactCommand, GetContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CreateContractHandler(IContactRepository contactRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                CreatedOn = DateTime.UtcNow,
                Email = request.Email,
                FullName = request.FullName,
                MobileNumber = request.MobileNumber,
                PreferredName = request.PreferredName,
                Title = request.Title
            };

            _contactRepository.Add(contact);
            await _contactRepository.SaveAsync();
            return _mapper.Map<GetContactDto>(contact);
        }
    }
}
