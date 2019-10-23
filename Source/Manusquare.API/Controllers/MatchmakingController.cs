using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Commands;
using Manusquare.API.Commands.Semantic.Matchmaking;
using Manusquare.API.Constants;
using Manusquare.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Annotations;

namespace Manusquare.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    public class MatchmakingController : ControllerBase
    {

        /// <summary>
        /// Returns an Allow HTTP header with the allowed HTTP methods.
        /// </summary>
        /// <returns>A 200 OK response.</returns>
        [HttpOptions]
        [SwaggerResponse(StatusCodes.Status200OK, "The allowed HTTP methods.")]
        public IActionResult Options()
        {
            HttpContext.Response.Headers.AppendCommaSeparatedValues(
                HeaderNames.Allow,
                HttpMethods.Get,
                HttpMethods.Head,
                HttpMethods.Options,
                HttpMethods.Post);
            return Ok();
        }


        /// <summary>
        /// Get all buyers
        /// </summary>
        [HttpGet(Name = MatchmakingControllerRoute.GetAllBuyers)]
        [SwaggerResponse(StatusCodes.Status200OK, "All buyers registered in the system", typeof(List<Buyer>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> GetBuyers(
            [FromServices] GetAllBuyersCommand command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get all suppliers
        /// </summary>
        [HttpGet(Name = MatchmakingControllerRoute.GetAllSuppliers)]
        [SwaggerResponse(StatusCodes.Status200OK, "All suppliers registered in the system", typeof(List<Supplier>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> GetSuppliers(
            [FromServices] GetAllSuppliersCommand command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get all transactional data
        /// </summary>
        [HttpGet(Name = MatchmakingControllerRoute.GetAllTransactionalData)]
        [SwaggerResponse(StatusCodes.Status200OK, "All transactional data registered in the system", typeof(List<TransactionalData>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> GetTransactionalData(
            [FromServices] GetAllTransactionalData command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get offers for a given order
        /// </summary>
        [HttpGet("{offerId}", Name = MatchmakingControllerRoute.GetOfferForOrder)]
        [SwaggerResponse(StatusCodes.Status200OK, "Get offers for a given id", typeof(List<Offer>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> GetOffers(
            [FromServices] GetOffersCommand command,
            int offerId,
            CancellationToken cancellationToken) => command.ExecuteAsync(offerId, cancellationToken);

    }
}