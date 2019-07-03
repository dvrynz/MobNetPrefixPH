using AutoMapper;

namespace MobNetPrefixPH.Services
{
    public interface IMapperService
    {
        IMapper Instance { get; }
    }

    public class MapperService : IMapperService
    {
        private IMapper _instance;

        public IMapper Instance
        {
            get
            {
                if(_instance == null)
                {
                    var mapperConfig = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Entities.NetworkProvider, Models.NetworkProvider>()
                            .ForMember(dst => dst.Network, src => src.MapFrom(source => source.network))
                            .ForMember(dst => dst.Prefixes, src => src.MapFrom(source => source.prefix));
                    });

                    _instance = mapperConfig.CreateMapper();
                }

                return _instance;
            }
        }
    }
}
