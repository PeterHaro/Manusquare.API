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
    [Route("[controller]")]
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
        [SwaggerResponse(StatusCodes.Status200OK, "All buyers registered in the system", typeof(Buyer))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> Get(
            [FromServices] GetAllBuyersCommand command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get all suppliers
        /// </summary>
        [HttpGet(Name = MatchmakingControllerRoute.GetAllSuppliers)]
        [SwaggerResponse(StatusCodes.Status200OK, "All suppliers registered in the system", typeof(Buyer))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> Get(
            [FromServices] GetAllSuppliersCommand command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

        /// <summary>
        /// Get all transactional data
        /// </summary>
        [HttpGet(Name = MatchmakingControllerRoute.GetAllTransactionalData)]
        [SwaggerResponse(StatusCodes.Status200OK, "All transactional data registered in the system", typeof(Buyer))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No buyers registered in the system")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> Get(
            [FromServices] GetAllTransactionalData command,
            CancellationToken cancellationToken) => command.ExecuteAsync(cancellationToken);

    }
}