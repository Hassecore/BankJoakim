using BankJoakim.Models.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BankJoakim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        public AccountsController()
        {
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Id = Guid.NewGuid(),
                    AccountName = "JoakimsHugeBankAccount",
                    Balance = 5000000000,
                    CreatedOn = DateTime.UtcNow
                }
            };
            
        }
    }
}
