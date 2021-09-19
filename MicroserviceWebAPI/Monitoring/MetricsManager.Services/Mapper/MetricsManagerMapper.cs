using AutoMapper;
using MetricsManager.Entities;
using MetricsManager.Service.Dto;

namespace MetricsManager.Service.Mapper
{
    public class MetricsManagerMapper : IMetricsManagerMapper
    {
        protected IMapper Mapper { get; }

        public MetricsManagerMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AgentAddDto, Agent>(); });

            Mapper = config.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider => Mapper.ConfigurationProvider;

        public T Map<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }
    }
}