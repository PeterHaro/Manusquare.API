using System;
using System.Threading;
using System.Threading.Tasks;
using Boxed.AspNetCore;
using Manusquare.API.Commands.Generic;
using Manusquare.API.Database;
using Manusquare.API.Models;
using Manusquare.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace Manusquare.API.Commands.Semantic.Matchmaking
{

    public class GetBuyersCommand : GetEntityCommand<Buyer>
    {
        public GetBuyersCommand(GenericRepository<Buyer> repo, IActionContextAccessor actionContextAccessor) : base(repo, actionContextAccessor)
        {
        }
    }
}