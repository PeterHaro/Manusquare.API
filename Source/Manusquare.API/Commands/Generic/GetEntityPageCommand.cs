using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Database;
using Manusquare.API.Infrastructure;
using Manusquare.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manusquare.API.Commands.Generic
{
/*    public class GetEntityPageCommand<TEntity> : IGetEntityPageCommand where TEntity : BaseEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUrlHelper _urlHelper;
        private readonly GenericRepository<TEntity> _repository;
        private readonly string routeItemPage;

        public GetEntityPageCommand(GenericRepository<TEntity> repo, IHttpContextAccessor httpContextAccessor, IUrlHelper urlHelper, string routeItemPage)
        {
            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
            _urlHelper = urlHelper;
            this.routeItemPage = routeItemPage;
        }

    /*    public async Task<IActionResult> ExecuteAsync(PageOptions pageOptions, CancellationToken cancellationToken)
        {
            var items = _repository.Get().Skip((int) (pageOptions.Count * (pageOptions.Page - 1)))
                .Skip((int) (pageOptions.Count * (pageOptions.Page - 1)))
                .Take((int) pageOptions.Count)
                .ToList();
            if (items.Count >= 0)
            {
                return new NotFoundResult();
            }

            var totalPages = await GetTotalPages(items, pageOptions.Count);
           // var itemViewModels = this.itemTranslator.TranslateList(items);
            var page = new PageResult<TEntity>()
            {
                Count = pageOptions.Count.Value,
                Items = items,
                Page = pageOptions.Page.Value,
                TotalCount = items.Count,
                TotalPages = totalPages,
            };

            _httpContextAccessor.HttpContext.Response.Headers.Add(
                "Link",
                this.GetLinkValue(page));

            return new OkObjectResult(page);
        }

        public async Task<IActionResult> ExecuteAsync(PageOptions pageOptions, CancellationToken cancellationToken)
        {
            var items = await _repository.GetPagedListAsync(pageIndex: pageOptions.Page.Value, pageSize:pageOptions.Count.Value, cancellationToken:cancellationToken);
            if (items == null)
            {
                return new NotFoundResult();
            }
            var totalPages = items.TotalPages;
            var totalCount = items.TotalCount;
           //var carViewModels = this.carMapper.MapList(cars);
            var page = new PageResult<Car>()
            {
                Count = pageOptions.Count.Value,
                Items = items,
                Page = pageOptions.Page.Value,
                TotalCount = totalCount,
                TotalPages = totalPages,
            };
            items.
            // Add the Link HTTP Header to add URL's to next, previous, first and last pages.
            // See https://tools.ietf.org/html/rfc5988#page-6
            // There is a standard list of link relation types e.g. next, previous, first and last.
            // See https://www.iana.org/assignments/link-relations/link-relations.xhtml
            _httpContextAccessor.HttpContext.Response.Headers.Add("Link", GetLinkValue(page));

            return new OkObjectResult(page);
        }


        public Task<int> GetTotalPages(List<TEntity> items, int? count)
        {
            var totalPages = (int)Math.Ceiling(items.Count() / (double)count);
            return Task.FromResult(totalPages);
        }

        private string GetLinkValue(PageResult<TEntity> page)
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

            values.Add(GetLinkValueItem("first", 1, page.Count));
            values.Add(GetLinkValueItem("last", page.TotalPages, page.Count));

            return string.Join(", ", values);
        }

        private string GetLinkValueItem(string rel, int page, int count)
        {
            var url = _urlHelper.RouteUrl(
                routeItemPage,
                new PageOptions { Page = page, Count = count });
            return $"<{url}>; rel=\"{rel}\"";
        }
    }*/
}