using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Commands.Generic;
using Manusquare.API.Database;
using Manusquare.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Manusquare.API.Commands.Semantic.Matchmaking
{
    public class GetOffersCommand : IGetEntityCommand
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;

        public GetOffersCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
        }

        /**
         * This generates all offers for a order id and stores em to the DB
         */
        public async Task<IActionResult> ExecuteAsync(int orderId, CancellationToken cancellationToken)
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
            return new OkObjectResult(offers);
        }

        private static int GetSupplierId(int amountOfSuppliers)
        {
            return GenerateRandomNumberInRange(0, amountOfSuppliers - 1);
        }

        private static int GenerateRandomNumberInRange(int minNumber, int maxNumber)
        {
            return new Random().Next(minNumber, maxNumber);
        }
    }
}