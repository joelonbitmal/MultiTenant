using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MultiTenant.WebAPI.Middlewares
{
    public class BranchAssignmentMiddleware
    {
        private readonly RequestDelegate _next;

        public BranchAssignmentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User;
            if (user.Identity.IsAuthenticated)
            {
                var branchClaims = user.FindAll("BranchId");

                if (branchClaims != null && branchClaims.Any())
                {
                    var branchIds = branchClaims.Select(claim => Guid.Parse(claim.Value)).ToList();
                    context.Items["BranchIds"] = branchIds;
                }
            }

            await _next(context);
        }
    }
}
