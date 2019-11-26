namespace Manusquare.API.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Semantic.Matching;
    using Constants;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using Models;
    using Swashbuckle.AspNetCore.Annotations;

    [Route("[controller]/[action]")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    public class Matching : ControllerBase
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
        /// Calculates the semantic score for a given rfq.
        /// </summary>
        /// <param name="command">The action command.</param>
        /// <param name="input">The RFQ query.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel the HTTP request.</param>
        /// <returns>A 201 Created response containing the newly created car or a 400 Bad Request if the car is
        /// invalid.</returns>
        [HttpPost("", Name = MatchingControllerRoute.PostRfq)]
        [SwaggerResponse(StatusCodes.Status201Created, "The car was created.", typeof(SemanticInput))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid RFQ query.")]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.")]
        public Task<IActionResult> Post(
            [FromServices] IGetSemanticScoreCommand command,
            [FromBody] SemanticInput input,
            CancellationToken cancellationToken) => command.ExecuteAsync(input);

    }
}