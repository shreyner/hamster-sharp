using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Monitoring.Shared.Http
{
    public class NotImplementedResult
    {
        [DefaultStatusCode(StatusCodes.Status501NotImplemented)]
        sealed class NotImplementedResult : ObjectResult
        {
            private const int DefaultStatusCode = StatusCodes.Status501NotImplemented;

            public NotImplementedResult() : base(DefaultStatusCode)
            {
            }
        }
    }
}