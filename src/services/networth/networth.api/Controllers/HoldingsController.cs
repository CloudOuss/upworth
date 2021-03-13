using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Securities.Queries.GetSecurityDetails;
using Microsoft.AspNetCore.Authorization;
using NetworthApplication.Holdings.AddHolding;

namespace NetworthApi.Controllers
{
    [Authorize]
    public class HoldingsController : ApiController
    {
        [HttpPost]
        public async Task<Guid> AddHolding([FromQuery] AddHoldingRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}
