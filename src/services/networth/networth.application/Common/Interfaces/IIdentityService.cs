
using System;

namespace NetworthApplication.Common.Interfaces
{
    public interface IIdentityService
    {
        string UserId { get; }
        string UserName { get; }
    }
}