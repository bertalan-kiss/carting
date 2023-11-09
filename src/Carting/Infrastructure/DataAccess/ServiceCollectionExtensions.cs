using Carting.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Carting.Infrastructure.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<ICartingRepository, CartingRepository>();
            return collection;
        }
    }
}

