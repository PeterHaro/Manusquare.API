namespace Manusquare.API.Commands.Semantic.Matching
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Boxed.AspNetCore;
    using Database;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Models;
    using ProcessUtility;

    public interface IGetSemanticScoreCommand : IAsyncCommand<SemanticInput>
    {
    }

    public class GetSemanticScoreCommand : IGetSemanticScoreCommand
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GetSemanticScoreCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context, IHostingEnvironment hostingEnvironment)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //TODO: IF THIS IS DUMB / WORKS BAD USE CLIWRAP https://github.com/Tyrrrz/CliWrap
        public async Task<IActionResult> ExecuteAsync(SemanticInput parameter, CancellationToken cancellationToken)
        {
            double retval = -1;

            //TODO: FIXME


            return new OkObjectResult(retval);
        }
    }
}