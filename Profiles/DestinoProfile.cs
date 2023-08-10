using api_jornada_milhas.Data.Dtos.DestinosDtos;
using api_jornada_milhas.Models;
using AutoMapper;

namespace api_jornada_milhas.Profiles;

public class DestinoProfile : Profile
{
    public DestinoProfile()
    {
        CreateMap<CreateDestinoDto, Destino>();
        CreateMap<Destino, ReadDestinoDto>();
        CreateMap<ReadDestinoDto, Destino>();
        CreateMap<UpdateDestinoDto, Destino>();
        CreateMap<Destino, UpdateDestinoDto>();
    }
}
