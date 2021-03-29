using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NetworthApplication.Holdings;
using NetworthApplication.Holdings.CreateHolding;
using NetworthApplication.Holdings.DeleteHolding;
using NetworthApplication.Holdings.GetHoldingById;
using NetworthApplication.Holdings.GetHoldings;
using NetworthApplication.Holdings.UpdateHolding;

namespace NetworthApi.Controllers
{
    [Authorize]
    public class HoldingsController : ApiController
    {
        [HttpGet]
        public async Task<List<HoldingVm>> GetAll()
        {
            return await Mediator.Send(new GetHoldingsRequest());
        }

        [HttpGet("{id}")]
        public async Task<HoldingVm> Get(Guid id)
        {
            return await Mediator.Send(new GetHoldingByIdRequest{Id = id});
        }

        [HttpPost]
        public async Task<Guid> Create(CreateHoldingRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateHoldingRequest request)
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
            await Mediator.Send(new DeleteHoldingRequest{Id = id});
            return NoContent();
        }

    }
}
