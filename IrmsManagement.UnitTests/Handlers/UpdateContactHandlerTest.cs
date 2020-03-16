using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Handlers;
using IrmsManagement.Data.Repositories.Interfaces;
using IrmsManagement.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.UnitTests.Handlers
{
    public class UpdateContactHandlerTest
    {
        private Mock<IContactRepository> _contactRepository = new Mock<IContactRepository>();
        private Mock<IMapper> _mapper = new Mock<IMapper>();

        private Contact _contact;
        private UpdateContactCommand _updateContactCommand;
        private GetContactDto _getContactDto;
        
        [Test]
        public async Task UpdateContractHandler_Handle()
        {
            _updateContactCommand = new UpdateContactCommand
            {
                Email = "Email",
                FullName = "Full name",
                MobileNumber = "88005553555",
                PreferredName = "Preffered name",
                Title = "Title"
            };

            _mapper
                .Setup(x => x.Map<GetContactDto>(It.IsAny<Contact>()))
                .Returns(new GetContactDto
                {
                    Email = _updateContactCommand.Email,
                    FullName = _updateContactCommand.FullName,
                    MobileNumber = _updateContactCommand.MobileNumber,
                    PreferredName = _updateContactCommand.PreferredName,
                    Title = _updateContactCommand.Title,
                });

            _contactRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(new Contact
                {
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }));

            var commandHandler = new UpdateContactHandler(_contactRepository.Object, _mapper.Object);
            _getContactDto = await commandHandler.Handle(_updateContactCommand, new CancellationToken());

            Assert.IsNotNull(_getContactDto);
            Assert.AreEqual(_updateContactCommand.Email, _getContactDto.Email);
            Assert.AreEqual(_updateContactCommand.FullName, _getContactDto.FullName);
            Assert.AreEqual(_updateContactCommand.MobileNumber, _getContactDto.MobileNumber);
            Assert.AreEqual(_updateContactCommand.PreferredName, _getContactDto.PreferredName);
            Assert.AreEqual(_updateContactCommand.Title, _getContactDto.Title);
        }
    }
}
