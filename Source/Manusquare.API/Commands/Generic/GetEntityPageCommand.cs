using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Database;
using Manusquare.API.Infrastructure;
using Manusquare.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manusquare.API.Commands.Generic
{
    public class GetEntityPageCommand<TEntity> : IGetEntityPageCommand where TEntity : BaseEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper _urlHelper;
        private readonly GenericRepository<TEntity> _repository;

        public GetEntityPageCommand(GenericRepository<TEntity> repo, IHttpContextAccessor httpContextAccessor, IUrlHelper urlHelper)
        {
            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
            _urlHelper = urlHelper;
        }

        public async Task<IActionResult> ExecuteAsync(PageOptions pageOptions, CancellationToken cancellationToken)
        {
            var cars = await _repository.GetPage(pageOptions.Page.Value, pageOptions.Count.Value, cancellationToken);
            if (cars == null)
            {
                return new NotFoundResult();
            }

            var (totalCount, totalPages) = await _repository.GetTotalPages(pageOptions.Count.Value, cancellationToken);
            var carViewModels = this.carMapper.MapList(cars);
            var page = new PageResult<Car>()
            {
                Count = pageOptions.Count.Value,
                Items = carViewModels,
                Page = pageOptions.Page.Value,
                TotalCount = totalCount,
                TotalPages = totalPages,
            };

            // Add the Link HTTP Header to add URL's to next, previous, first and last pages.
            // See https://tools.ietf.org/html/rfc5988#page-6
            // There is a standard list of link relation types e.g. next, previous, first and last.
            // See https://www.iana.org/assignments/link-relations/link-relations.xhtml
            _httpContextAccessor.HttpContext.Response.Headers.Add("Link", GetLinkValue(page));

            return new OkObjectResult(page);
        }

        private string GetLinkValue(PageResult<Car> page)
        {
            var values = new List<string>(4);

            if (page.HasNextPage)
            {
                values.Add(this.GetLinkValueItem("next", page.Page + 1, page.Count));
            }

            if (page.HasPreviousPage)
            {
                values.Add(this.GetLinkValueItem("previous", page.Page - 1, page.Count));
            }

            values.Add(this.GetLinkValueItem("first", 1, page.Count));
            values.Add(this.GetLinkValueItem("last", page.TotalPages, page.Count));

            return string.Join(", ", values);
        }

        /*private string GetLinkValueItem(string rel, int page, int count)
        {
            var url = this.urlHelper.AbsoluteRouteUrl(
                CarsControllerRoute.GetCarPage,
                new PageOptions { Page = page, Count = count });
            return $"<{url}>; rel=\"{rel}\"";
        }*/
    }
}