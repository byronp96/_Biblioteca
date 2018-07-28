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

                cfg.CreateMap<Models.Permiso, DATA.Permiso>();
                cfg.CreateMap<DATA.Permiso, Models.Permiso>();

                cfg.CreateMap<Models.Recargo, DATA.Recargo>();
                cfg.CreateMap<DATA.Recargo, Models.Recargo>();

                cfg.CreateMap<Models.Usuario, DATA.Usuario>();
                cfg.CreateMap<DATA.Usuario, Models.Usuario>();
            });
        }
    }
}