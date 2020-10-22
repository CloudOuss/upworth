using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Securities.Queries.GetSecurityDetails;

namespace NetworthApi.Controllers
{
    public class SecuritiesController : ApiController
    {
        [HttpGet]
        public async Task<SecurityVm> Get([FromQuery] GetSecurityDetailsQuery request)
        {
            return await Mediator.Send(request);
        }
    }
}
