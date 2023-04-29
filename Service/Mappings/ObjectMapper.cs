using AutoMapper;
using System;

namespace Service.Mappings
{
    public static class ObjectMapper
    {
        //İhtiytaç olduğu taktirde (lazy loading) çalışsın.
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
