using Carting.Infrastructure.Kafka.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carting.Infrastructure.Kafka
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKafkaConsumer<TMessage>(this IServiceCollection collection) where TMessage : new()
        {
            collection.AddSingleton<IKafkaConsumerService, KafkaConsumerService<TMessage>>();
            return collection;
        }
    }
}

