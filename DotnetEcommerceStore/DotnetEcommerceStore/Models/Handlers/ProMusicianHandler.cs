using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Handlers
{
    public class ProMusicianHandler : AuthorizationHandler<ProMusicianRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProMusicianRequirment requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Professional Musician"))
            {
                return Task.CompletedTask;
            }

            bool proMusician = bool.Parse(context.User.FindFirst(c => c.Type == "Professional Musician").Value);

            if (proMusician == requirement.Musician)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
