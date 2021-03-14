using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NetworthApplication.Holdings;
using NetworthApplication.Holdings.AddHolding;
using NetworthApplication.Holdings.GetHoldingById;

namespace NetworthApi.Controllers
{
    
    public class HoldingsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<Guid> AddHoldingAsync(AddHoldingRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpGet]
        public async Task<HoldingVm> GetHoldingByIdAsync([FromQuery] GetHoldingByIdRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
