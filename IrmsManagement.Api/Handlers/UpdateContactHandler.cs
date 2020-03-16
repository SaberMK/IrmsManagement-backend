using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Data.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Handlers
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, GetContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public UpdateContactHandler(IContactRepository contactRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetContactDto> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _contactRepository.GetById(request.Id);

            if (entity == null)
                return null;

            entity.ModifiedOn = DateTime.UtcNow;
            entity.PreferredName = request.PreferredName;
            entity.Title = request.Title;
            entity.MobileNumber = request.MobileNumber;
            entity.FullName = request.FullName;
            entity.Email = request.Email;

            _contactRepository.Update(entity);
            await _contactRepository.SaveAsync();
            var entityResponse = _mapper.Map<GetContactDto>(entity);
            return entityResponse;
        }
    }
}
