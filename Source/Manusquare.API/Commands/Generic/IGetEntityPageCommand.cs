using Boxed.AspNetCore;
using Manusquare.API.ViewModels;

namespace Manusquare.API.Commands.Generic
{
    public interface IGetEntityPageCommand : IAsyncCommand<PageOptions>
    {

    }
}