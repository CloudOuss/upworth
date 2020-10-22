using System;
using NetworthApplication.Common.Interfaces;

namespace NetworthInfrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
