using api_jornada_milhas.Data.Dtos.DepoimentosDtos;
using api_jornada_milhas.Models;
using AutoMapper;

namespace api_jornada_milhas.Profiles;

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
