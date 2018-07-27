using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace UI
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Categoria, DATA.Categoria>();
                cfg.CreateMap<DATA.Categoria, Models.Categoria>();

                cfg.CreateMap<Models.Cliente, DATA.Cliente>();
                cfg.CreateMap<DATA.Cliente, Models.Cliente>();
            });
        }
    }
}