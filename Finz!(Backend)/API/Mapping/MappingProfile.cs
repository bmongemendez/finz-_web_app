using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DO.Objects;

namespace API.Mapping
{
    // Implementamos el casteo de objetos del automapper para no tener referencias circulares
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            // Representa el casting del objeto a el similar 
            // Desde DO hacia DataModels 
            // Domain to Resource

            CreateMap<data.Ahorros, DataModels.Ahorros>().ReverseMap();

            CreateMap<data.Categorias, DataModels.Categorias>().ReverseMap();

            CreateMap<data.Dinero, DataModels.Dinero>().ReverseMap();

            CreateMap<data.Gastos, DataModels.Gastos>().ReverseMap();

            CreateMap<data.GastosFijos, DataModels.GastosFijos>().ReverseMap();

            CreateMap<data.Retos, DataModels.Retos>().ReverseMap();

            CreateMap<data.Usuario, DataModels.Usuario>().ReverseMap();


        }

    }
}