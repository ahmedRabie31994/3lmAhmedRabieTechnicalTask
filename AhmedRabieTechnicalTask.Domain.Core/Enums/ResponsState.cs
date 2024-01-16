using System;
using System.Collections.Generic;
using System.Text;

namespace AhmedRabieTechnicalTask.Domain.Core.Enums
{
    public enum ResponsState
    {
        Success = 100,
        Error = 101,
        ValidationError = 102,
        NotFound = 103,
        AccessDenied = 104,
        AuthenticationError = 105,
        ProcessError = 106,
        InvalidInput = 107,
    }
}
