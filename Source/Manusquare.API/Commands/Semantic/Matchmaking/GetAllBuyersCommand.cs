using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Commands.Generic;
using Manusquare.API.Database;
using Manusquare.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Manusquare.API.Commands.Semantic.Matchmaking
{
    public class GetAllBuyersCommand : IGetAllCommand
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;

        public GetAllBuyersCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            List<Buyer> retval = await _context.Buyers.ToListAsync(cancellationToken);
            List<TransactionalData> historicalData = await this._context.TransactionalData.ToListAsync(cancellationToken);
            foreach (var transaction in historicalData)
            {
                foreach (var buyer in retval)
                {
                    if (buyer.Id == transaction.BuyerId)
                    {
                        buyer.AddTransactionalData(transaction);
                        break;
                    }
                }
            }
            return new OkObjectResult(retval);
        }
    }
}