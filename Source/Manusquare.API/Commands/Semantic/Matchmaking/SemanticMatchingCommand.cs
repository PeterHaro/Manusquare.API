// ReSharper disable ArrangeThisQualifier
namespace Manusquare.API.Commands.Semantic.Matchmaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Boxed.AspNetCore;
    using Database;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Models;

   /* public interface IPerformSemanticMatching : IAsyncCommand<SemanticInput> {}

    public class SemanticMatchingCommand : IPerformSemanticMatching
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;

        public SemanticMatchingCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> ExecuteAsync(SemanticInput parameter, CancellationToken cancellationToken)
        {
            List<Offer> offers = new List<Offer>();
            int length = GenerateRandomNumberInRange(3, 10);
            List<int> suppliers = await _context.Suppliers.Select(entity => entity.Id).ToListAsync(cancellationToken);
            int existingOffers = await _context.Offers.CountAsync(cancellationToken);
            for (int i = 0; i <length; i++)
            {
                Offer offer = new Offer
                {
                    Id = (existingOffers + i + 1),
                    OrderId = orderId,
                    SupplierId = GetSupplierId(suppliers.Count),
                    DistanceInKm = GenerateRandomNumberInRange(15, 105),
                    Price = GenerateRandomNumberInRange(0, 2),
                    SemanticSimilarity = new Random().NextDouble()
                };
                offers.Add(offer);
            }

            await _context.Offers.AddRangeAsync(offers, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new OkObjectResult(new Object());
        }
    }*/


}