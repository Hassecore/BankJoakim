using BankJoakim.Controllers;
using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Resources.Accounts;
using BankJoakim.Resources.Deposits;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakimTests.UnitTests.Deposits
{
    [TestClass]
    public class DepositsControllerTests
    {
        static Mock<IMediator> _mediator { get; set; }
        DepositsController _controller;

        DepositCreateResource createResource;
        CommandResult<DepositResource> commandResult;


        [TestInitialize]
        public void Initialize()
        {
            _mediator = new Mock<IMediator>();
            _controller = new DepositsController(_mediator.Object);

            createResource = new DepositCreateResource
            {
                AccountId = Guid.NewGuid(),
                Ammount = 10
            };

            var createdOn = DateTime.Now;
            commandResult = new CommandResult<DepositResource>
            {
                HasSucceeded = true,
                Resource = new DepositResource
                {
                    Id = Guid.NewGuid(),
                    AccountId = createResource.AccountId.Value,
                    Ammount = createResource.Ammount,
                    CreatedOn = createdOn
                }
            };
        }

        [TestMethod]
        public void CreateDeposit_WhenDepositIsCreated_ShouldReturnOk()
        {
            _mediator.Setup(m => m.Send(It.IsAny<DepositCreateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(commandResult);

            var result = _controller.CreateDeposit(createResource).Result;

            var depositResult = (result as OkObjectResult).Value as DepositResource;

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            Assert.AreEqual(createResource.Ammount, depositResult.Ammount);
            Assert.AreEqual(createResource.AccountId, depositResult.AccountId);
        }

        [TestMethod]
        public void CreateDeposit_WhenCommandResultIsFailed_ShouldReturnBadRequest()
        {
            commandResult.HasSucceeded = false;
            commandResult.ErrorMessage = "Some error";

            _mediator.Setup(m => m.Send(It.IsAny<DepositCreateCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(commandResult);

            var result = _controller.CreateDeposit(createResource).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual((int)HttpStatusCode.BadRequest, ((BadRequestObjectResult)result).StatusCode);

            Assert.AreEqual(commandResult.ErrorMessage, (result as BadRequestObjectResult).Value);
        }

        [TestMethod]
        public void CreateDeposit_WhenModelStateIsNotValid_ShouldReturnBadRequest()
        {
            _controller.ModelState.AddModelError("test1", "test2");

            var result = _controller.CreateDeposit(createResource).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            Assert.AreEqual((int)HttpStatusCode.BadRequest, ((BadRequestResult)result).StatusCode);
        }
    }
}
