using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Handlers
{
    public class ProMusicianRequirment : IAuthorizationRequirement
    {
        public bool Musician;

        public ProMusicianRequirment(bool musician)
        {
            Musician = musician;
        }

    }
}
