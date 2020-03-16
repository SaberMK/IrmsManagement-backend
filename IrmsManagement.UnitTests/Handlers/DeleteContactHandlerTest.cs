using AutoMapper;
using IrmsManagement.Api.Commands;
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
    public class DeleteContactHandlerTest
    {
        private Mock<IContactRepository> _contactRepository = new Mock<IContactRepository>();
        private Mock<IMapper> _mapper = new Mock<IMapper>();

        [Test]
        public async Task DeleteContactHandler_Handle()
        {
            var deleteCommand = new DeleteContactCommand();

            _contactRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(
                new Contact
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }));

            var commandHandler = new DeleteContractHandler(_contactRepository.Object, _mapper.Object);
            var result = await commandHandler.Handle(deleteCommand, new CancellationToken());

            Assert.AreEqual(result, true);
        }
    }
}
