using api_alura_challenge.Data.Dtos.DestinosDtos;
using api_alura_challenge.Models;
using AutoMapper;

namespace api_alura_challenge.Profiles;

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
