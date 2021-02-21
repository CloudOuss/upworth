using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Securities.Queries.GetSecurityDetails;
using Microsoft.AspNetCore.Authorization;

namespace NetworthApi.Controllers
{
    [Authorize]
    public class SecuritiesController : ApiController
    {
        [HttpGet]
        public async Task<SecurityVm> Get([FromQuery] GetSecurityDetailsQuery request)
        {
            return await Mediator.Send(request);
        }
    }
}
