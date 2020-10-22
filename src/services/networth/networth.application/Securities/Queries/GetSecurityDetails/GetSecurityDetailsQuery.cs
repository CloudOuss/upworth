using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetworthApplication.Common.Interfaces;

namespace NetworthApplication.Securities.Queries.GetSecurityDetails
{
    public class GetSecurityDetailsQuery : IRequest<SecurityVm>
    {
        public string Ticker { get; set; }
    }

    public class GetSecurityDetailsQueryHandler : IRequestHandler<GetSecurityDetailsQuery, SecurityVm>
    {
        private readonly ISecuritiesService _securitiesService;
        private readonly IMapper _mapper;

        public GetSecurityDetailsQueryHandler(ISecuritiesService securitiesService, IMapper mapper)
        {
            _securitiesService = securitiesService;
            _mapper = mapper;
        }

        public async Task<SecurityVm> Handle(GetSecurityDetailsQuery request, CancellationToken cancellationToken)
        {

            return  _mapper.Map<SecurityVm>(await _securitiesService.GetSecurityDetailsAsync(request.Ticker));
        }
    }
}
