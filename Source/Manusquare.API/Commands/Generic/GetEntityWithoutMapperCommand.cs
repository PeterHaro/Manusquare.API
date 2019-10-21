using System;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Database;
using Manusquare.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace Manusquare.API.Commands.Generic
{
    public class GetEntityCommand<TEntity> : IGetEntityCommand where TEntity : BaseEntity
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly GenericRepository<TEntity> _repository;

        public GetEntityCommand(GenericRepository<TEntity> repo, IActionContextAccessor actionContextAccessor)
        {
            _repository = repo;
            _actionContextAccessor = actionContextAccessor;
        }

        public async Task<IActionResult> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var item = await _repository.AsyncGetById(id, cancellationToken);
            if (item == null)
            {
                return new NotFoundResult();
            }

            var httpContext = _actionContextAccessor.ActionContext.HttpContext;
            if (httpContext.Request.Headers.TryGetValue(HeaderNames.IfModifiedSince, out var stringValues))
            {
                if (DateTimeOffset.TryParse(stringValues, out var modifiedSince) &&
                    (modifiedSince >= item.Modified))
                {
                    return new StatusCodeResult(StatusCodes.Status304NotModified);
                }
            }

            httpContext.Response.Headers.Add(HeaderNames.LastModified, item.Modified.ToString("R"));
            return new OkObjectResult(item);
        }
    }
}