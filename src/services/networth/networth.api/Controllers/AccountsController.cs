using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Accounts;
using NetworthApplication.Accounts.CreateAccount;
using NetworthApplication.Accounts.GetAccounts;
using NetworthApplication.Accounts.UpdateAccount;

namespace NetworthApi.Controllers
{
    [Authorize]
    public class AccountsController : ApiController
    {

        [HttpGet]
        public async Task<List<AccountVm>> Get()
        {
            return await Mediator.Send(new GetAccountsRequest());
        }

        [HttpPost]
        public async Task<Guid> Create(CreateAccountRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateAccountRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(request);

            return NoContent();
        }
    }
}
