using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manusquare.API.Models;

namespace Manusquare.API.Repositories.Matchmaking
{
    public interface IBuyerRepository
    {
        Task<Car> Add(Buyer buyer, CancellationToken cancellationToken);

        Task Delete(Buyer buyer, CancellationToken cancellationToken);

        Task<Buyer> Get(int buyerId, CancellationToken cancellationToken);

        Task<ICollection<Buyer>> GetPage(int page, int count, CancellationToken cancellationToken);

        Task<ICollection<Buyer>> GetRange(int fromId, int toId, CancellationToken cancellationToken);

        Task<(int totalCount, int totalPages)> GetTotalPages(int count, CancellationToken cancellationToken);

        Task<Car> Update(Buyer buyer, CancellationToken cancellationToken);
    }
}