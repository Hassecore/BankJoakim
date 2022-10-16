using BankJoakim.MediatR.CommandHandlers;
using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Deposits;
using BankJoakim.Resources.Deposits;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;

namespace BankJoakimTests.UnitTests.Deposits
{
    [TestClass]
    public class DepositCreateCommandHandlerTests
    {
        static Mock<IDepositsRepository> _depositsRepository { get; set; }
        static Mock<IAccountsRepository> _accountsRepository { get; set; }
        DepositCreateCommandHandler _handler { get; set; }

        DepositCreateResource createResource;
        Account account;

        [TestInitialize]
        public void Initialize()
        {
            _depositsRepository = new Mock<IDepositsRepository>();
            _accountsRepository = new Mock<IAccountsRepository>();

            _handler = new DepositCreateCommandHandler(_depositsRepository.Object, _accountsRepository.Object);

            createResource = new DepositCreateResource
            {
                AccountId = Guid.NewGuid(),
                Ammount = 1000
            };

            account = new Account
            {
                Id = Guid.NewGuid(),
                AccountName = "some account name",
                Iban = "some iban",
                Balance = 50,
                CreatedOn = DateTime.Now,
                CustomerId = Guid.NewGuid()
            };

        }

        [TestMethod]
        public void HandleCreateDepositCommand_WhenAccountExists_ShouldCreateDeposit()
        {
            _accountsRepository.Setup(ar => ar.GetById(It.IsAny<Guid>())).Returns(account);

            var result = _handler.Handle(new DepositCreateCommand(createResource), new CancellationToken()).Result;

            Assert.IsNotNull(result);

            Assert.IsTrue(result.HasSucceeded);

            Assert.AreEqual(createResource.Ammount * 0.999, result.Resource.Ammount);
            Assert.AreEqual(createResource.AccountId, result.Resource.AccountId);
        }

        [TestMethod]
        public void HandleCreateDepositCommand_WhenAccountDoesNotExist_ShouldNotCreateResource()
        {
            _accountsRepository.Setup(ar => ar.GetById(It.IsAny<Guid>())).Returns((Account)null);

            var result = _handler.Handle(new DepositCreateCommand(createResource), new CancellationToken()).Result;

            Assert.IsNotNull(result);

            Assert.IsFalse(result.HasSucceeded);
            Assert.IsNotNull(result.ErrorMessage);
            Assert.IsNull(result.Resource);
        }
    }
}