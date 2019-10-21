using System;
using System.Threading;
using System.Threading.Tasks;
using Boxed.AspNetCore;
using Manusquare.API.Database;
using Manusquare.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace Manusquare.API.Commands.Semantic.Matchmaking
{
    public interface IGetBuyerCommand : IAsyncCommand<int>
    {
    }

    // TODO: IMPLEMENT ME
    public class GetBuyerCommand : IGetBuyerCommand
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly MatchmakingContext _context;

        public GetBuyerCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context)
        {
            this._actionContextAccessor = actionContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> ExecuteAsync(int carId, CancellationToken cancellationToken)
        {
            var car = await this._context.FindAsync<int>(carId, cancellationToken);
            if (car == null)
            {
                return new NotFoundResult();
            }

            var httpContext = this._actionContextAccessor.ActionContext.HttpContext;
            if (httpContext.Request.Headers.TryGetValue(HeaderNames.IfModifiedSince, out var stringValues))
            {
                if (DateTimeOffset.TryParse(stringValues, out var modifiedSince) &&
                    (modifiedSince >= car.Modified))
                {
                    return new StatusCodeResult(StatusCodes.Status304NotModified);
                }
            }

            //var carViewModel = this.carMapper.Map(car);
            httpContext.Response.Headers.Add(HeaderNames.LastModified, car.Modified.ToString("R"));
            return new OkObjectResult(null);
        }
    }
}