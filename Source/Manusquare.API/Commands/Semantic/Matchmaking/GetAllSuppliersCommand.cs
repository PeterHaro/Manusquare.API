using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Commands.Generic;
using Manusquare.API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Manusquare.API.Commands.Semantic.Matchmaking
{
    public class GetAllSuppliersCommand : IGetAllCommand
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;

        public GetAllSuppliersCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            var retval = await _context.Suppliers.ToListAsync(cancellationToken);
            return new OkObjectResult(retval);
        }
    }
}