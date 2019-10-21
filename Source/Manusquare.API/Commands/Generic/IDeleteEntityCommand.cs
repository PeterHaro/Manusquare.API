using Boxed.AspNetCore;

namespace Manusquare.API.Commands.Generic
{
    public interface IDeleteEntityCommand : IAsyncCommand<int>
    {
    }
}