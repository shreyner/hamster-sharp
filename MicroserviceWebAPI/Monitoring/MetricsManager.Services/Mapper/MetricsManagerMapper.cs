using System.Collections.Generic;
using Agent.Client.Dto;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgentAddDto, Entities.Agent>();
                cfg.CreateMap<IEnumerable<CpuMetricResponse>, IEnumerable<CpuMetric>>();
                cfg.CreateMap<IEnumerable<HddMetricResponse>, IEnumerable<HddMetric>>();
            });

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