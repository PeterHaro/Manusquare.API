namespace Manusquare.API.Commands
{
    using Manusquare.API.ViewModels;
    using Boxed.AspNetCore;

    public interface IGetCarPageCommand : IAsyncCommand<PageOptions>
    {
    }
}
