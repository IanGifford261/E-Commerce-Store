using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Handlers
{
    public class ProMusicianRequirment : AuthorizationHandler<ProMusicianRequirment>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProMusicianRequirment requirement)
        {
            throw new NotImplementedException();
        }
    }
}
