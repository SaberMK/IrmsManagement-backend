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
    public class CreateContractHandlerTest
    {
        private IContactRepository _contactRepository;
        private Mock<IMapper> _mapper = new Mock<IMapper>();

        private Contact _contact;
        private CreateContactCommand _createContactCommand;
        private GetContactDto _getContactDto;
        [SetUp]
        public void Setup()
        {
            _contactRepository = Mock.Of<IContactRepository>();

        }

        [Test]
        public async Task CreateContractHandler_Handle()
        {
            _createContactCommand = new CreateContactCommand
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
                    Email = _createContactCommand.Email,
                    FullName = _createContactCommand.FullName,
                    MobileNumber = _createContactCommand.MobileNumber,
                    PreferredName = _createContactCommand.PreferredName,
                    Title = _createContactCommand.Title,
                });


            var commandHandler = new CreateContractHandler(_contactRepository, _mapper.Object);
            _getContactDto = await commandHandler.Handle(_createContactCommand, new CancellationToken());

            Assert.IsNotNull(_getContactDto);
            Assert.AreEqual(_createContactCommand.Email, _getContactDto.Email);
            Assert.AreEqual(_createContactCommand.FullName, _getContactDto.FullName);
            Assert.AreEqual(_createContactCommand.MobileNumber, _getContactDto.MobileNumber);
            Assert.AreEqual(_createContactCommand.PreferredName, _getContactDto.PreferredName);
            Assert.AreEqual(_createContactCommand.Title, _getContactDto.Title);
        }
    }
}
