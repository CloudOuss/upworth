
using System;

namespace NetworthApplication.Common.Interfaces
{
    public interface IIdentityService
    {
        Guid UserId { get; }
        string UserName { get; }
    }
}