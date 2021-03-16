using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Accounts;
using NetworthApplication.Accounts.CreateAccount;
using NetworthApplication.Accounts.DeleteAccount;
using NetworthApplication.Accounts.GetAccountById;
using NetworthApplication.Accounts.GetAccounts;
using NetworthApplication.Accounts.UpdateAccount;

namespace NetworthApi.Controllers
{
    [Authorize]
    public class AccountsController : ApiController
    {

        [HttpGet]
        public async Task<List<AccountVm>> GetAll()
        {
            return await Mediator.Send(new GetAccountsRequest());
        }

        [HttpGet("{id}")]
        public async Task<AccountVm> Get(Guid id)
        {
            return await Mediator.Send(new GetAccountByIdRequest{Id = id});
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteAccountRequest{Id = id});
            return NoContent();
        }
    }
}
