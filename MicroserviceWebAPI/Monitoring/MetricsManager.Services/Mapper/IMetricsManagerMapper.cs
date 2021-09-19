using AutoMapper;

namespace MetricsManager.Service.Mapper
{
    public interface IMetricsManagerMapper
    {
        IConfigurationProvider ConfigurationProvider { get; }

        T Map<T>(object source);

        void Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}