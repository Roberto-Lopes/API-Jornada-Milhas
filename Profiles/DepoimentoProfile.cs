using api_alura_challenge.Data.Dtos.DepoimentosDtos;
using api_alura_challenge.Models;
using AutoMapper;

namespace api_alura_challenge.Profiles;

public class DepoimentoProfile :Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CreateDepoimentoDto, Depoimento>();
        CreateMap<Depoimento, ReadDepoimentoDto>();
        CreateMap<UpdateDepoimentoDto, Depoimento>();
        CreateMap<Depoimento, UpdateDepoimentoDto>();
    }
}
