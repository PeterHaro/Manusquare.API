namespace Manusquare.API.Commands
{
    using Manusquare.API.ViewModels;
    using Boxed.AspNetCore;

    public interface IPostCarCommand : IAsyncCommand<SaveCar>
    {
    }
}
