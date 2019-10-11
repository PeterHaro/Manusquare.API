namespace Manusquare.API.Commands
{
    using Manusquare.API.ViewModels;
    using Boxed.AspNetCore;

    public interface IPutCarCommand : IAsyncCommand<int, SaveCar>
    {
    }
}
