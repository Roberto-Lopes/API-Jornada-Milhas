using api_alura_challenge.Data;
using api_alura_challenge.Data.Dtos;
using api_alura_challenge.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api_alura_challenge.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentosController : ControllerBase
{
    private DepoimentoContext _context;
    private IMapper _mapper;
    private static readonly Random random = new Random();

    public DepoimentosController(DepoimentoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo depoimento
    /// </summary>
    /// <param name="depoimentoDto">Dados necessários para criar um novo depoimento</param>
    /// <returns></returns>
    /// <response code="201">Caso o depoimento seja criado com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaDepoimento([FromBody] CreateDepoimentoDto depoimentoDto)
    {
        Depoimento depoimento = _mapper.Map<Depoimento>(depoimentoDto);
        _context.Add(depoimento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaDepoimentoPorId), new { id = depoimento.Id }, depoimento);
    }

    /// <summary>
    /// Lista todos os depoimentos cadastrados no banco de dados
    /// </summary>
    /// <param name="skip">Quantidade de elementos para pular</param>
    /// <param name="take">Quantidade de elementos na página</param>
    /// <returns></returns>
    /// <response code="200">Caso a pesquisa seja realizada com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadDepoimentoDto> BuscaDepoimentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        List<ReadDepoimentoDto> depoimentos = _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.OrderBy(depoimentos => depoimentos.Id).Skip(skip).Take(take));
        return depoimentos;
    }

    /// <summary>
    /// Lista apenas um depoimento a partir do Id fornecido
    /// </summary>
    /// <param name="id">Id do depoimento a ser pesquisado</param>
    /// <returns></returns>
    /// <response code="200">Caso a pesquisa seja realizada com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult BuscaDepoimentoPorId(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        var depoimentoDto = _mapper.Map<ReadDepoimentoDto>(depoimento);
        return Ok(depoimentoDto);
    }

    /// <summary>
    /// Atualiza todos os campos de um depoimento
    /// </summary>
    /// <param name="id">Id do depoimento a ser atualizado</param>
    /// <param name="depoimentoDto">Dados necessários para atualizar o depoimento</param>
    /// <returns></returns>
    /// <response code="204">Caso a atualização seja realizada com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaDepoimentoPorId(int id, UpdateDepoimentoDto depoimentoDto)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _mapper.Map(depoimentoDto, depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Lista de forma aleatória os depoimentos da página Home
    /// </summary>
    /// <param name="take">Quantidade de depoimentos a serem listados</param>
    /// <returns></returns>
    /// <response code="200">Caso os depoimentos sejam listados com sucesso</response>
    [HttpGet]
    [Route("home")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult BuscaDepoimentoHome([FromQuery] int take = 3)
    {
        List<ReadDepoimentoDto> depoimentos = _mapper.Map<List<ReadDepoimentoDto>>(_context.Depoimentos.OrderBy(depoimentos => depoimentos.Id).ToList());
        if (depoimentos == null) return NoContent();
        List<ReadDepoimentoDto> depoimentosAleatorios = depoimentos.OrderBy(x => random.Next()).Take(take).ToList();
        return Ok(depoimentosAleatorios);
    }

    /// <summary>
    /// Atualiza apenas os campos solicitados de um depoimento
    /// </summary>
    /// <param name="id">Id do depoimento a ser atualizado</param>
    /// <param name="patch">Campo e valor a ser atualizado</param>
    /// <returns></returns>
    /// <response code="204">Caso o depoimento seja atualizado com sucesso</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaDepoimentoParcial(int id, JsonPatchDocument<UpdateDepoimentoDto> patch)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        var depoimentoParaAtualizar = _mapper.Map<UpdateDepoimentoDto>(depoimento);
        patch.ApplyTo(depoimentoParaAtualizar, ModelState);

        if (!TryValidateModel(depoimentoParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(depoimentoParaAtualizar, depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um depoimento a partir do Id fornecido
    /// </summary>
    /// <param name="id">Id do depoimento a ser deletado</param>
    /// <returns></returns>
    /// <response code="204">Caso o depoimento seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaDepoimento(int id)
    {
        var depoimento = _context.Depoimentos.FirstOrDefault(depoimento => depoimento.Id == id);
        if (depoimento == null) return NotFound();
        _context.Remove(depoimento);
        _context.SaveChanges();
        return NoContent();
    }

}
