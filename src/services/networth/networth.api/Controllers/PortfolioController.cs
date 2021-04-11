using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworthApplication.Portfolio;
using NetworthApplication.Portfolio.GetPortfolio;

namespace NetworthApi.Controllers
{
    public class PortfolioController : ApiController
    {
        [HttpGet]
        public async Task<PortfolioVm> GetPortfolio()
        {
            return await Mediator.Send(new GetPortfolioRequest());
        }
    }
}
