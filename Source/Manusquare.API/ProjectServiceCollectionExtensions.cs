using Manusquare.API.Commands.Semantic.Matchmaking;

namespace Manusquare.API
{
    using Manusquare.API.Commands;
    using Manusquare.API.Mappers;
    using Manusquare.API.Repositories;
    using Manusquare.API.Services;
    using Manusquare.API.ViewModels;
    using Boxed.Mapping;
    using Commands.Semantic.Matching;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IDeleteCarCommand, DeleteCarCommand>()
                .AddSingleton<IGetCarCommand, GetCarCommand>()
                .AddSingleton<GetAllBuyersCommand, GetAllBuyersCommand>()
                .AddSingleton<GetAllSuppliersCommand, GetAllSuppliersCommand>()
                .AddSingleton<GetAllTransactionalData, GetAllTransactionalData>()
                .AddSingleton<GetOffersCommand, GetOffersCommand>()
                .AddSingleton<IGetSemanticScoreCommand, GetSemanticScoreCommand>()
                .AddSingleton<IGetCarPageCommand, GetCarPageCommand>()
                .AddSingleton<IPatchCarCommand, PatchCarCommand>()
                .AddSingleton<IPostCarCommand, PostCarCommand>()
                .AddSingleton<IPutCarCommand, PutCarCommand>();

        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services
                .AddSingleton<IMapper<Models.Car, Car>, CarToCarMapper>()
                .AddSingleton<IMapper<Models.Car, SaveCar>, CarToSaveCarMapper>()
                .AddSingleton<IMapper<SaveCar, Models.Car>, CarToSaveCarMapper>();

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<ICarRepository, CarRepository>();

        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
                .AddSingleton<IClockService, ClockService>();
    }
}
