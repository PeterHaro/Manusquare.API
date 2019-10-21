using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Database;
using Microsoft.AspNetCore.Mvc;

namespace Manusquare.API.Commands.Generic
{
    public class DeleteEntityCommand<T> : IDeleteEntityCommand where T : class
    {
        private readonly GenericRepository<T> _repository;

        public DeleteEntityCommand(GenericRepository<T> repo)
        {
            this._repository = repo;
        }

        public async Task<IActionResult> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var item = await _repository.AsyncGetById(id, cancellationToken);
            if (item == null)
            {
                return new NotFoundResult();
            }

            await _repository.DeleteAsync(item);
            return new NoContentResult();
        }
    }
}