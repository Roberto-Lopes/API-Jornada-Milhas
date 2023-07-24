﻿using api_alura_challenge.Data.Contexts;
using api_alura_challenge.Data.Dtos.DestinosDtos;
using api_alura_challenge.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api_alura_challenge.Controllers;

[ApiController]
[Route("[controller]")]
public class DestinosController : ControllerBase
{
    public ApplicationContext _context { get; set; }
    public IMapper _mapper { get; set; }
    public DestinosController(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um novo destino
    /// </summary>
    /// <param name="destinoDto">Dados necessários para criar um novo destino</param>
    /// <returns></returns>
    /// <response code="201">Caso o destino seja criado com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaDestino([FromBody] CreateDestinoDto destinoDto)
    {
        Destino destino = _mapper.Map<Destino>(destinoDto);
        _context.Add(destino);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaDestinoPorId), new { id = destino.Id }, destino);
    }

    /// <summary>
    /// Lista todos os destinos cadastrados no banco de dados
    /// </summary>
    /// <param name="skip">Quantidade de elementos para pular</param>
    /// <param name="take">Quantidade de elementos na página</param>
    /// <returns></returns>
    /// <response code="200">Caso a pesquisa seja realizada com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadDestinoDto> BuscaDestinos([FromQuery] int skip = 0, int take = 50)
    {
        List<ReadDestinoDto> destinos = _mapper.Map<List<ReadDestinoDto>>(_context.Destinos.OrderBy(destinos => destinos.Id).Skip(skip).Take(take));
        return destinos;
    }

    /// <summary>
    /// Lista apenas um destino a partir do Id fornecido
    /// </summary>
    /// <param name="id">Id do destino a ser pesquisado</param>
    /// <returns></returns>
    /// <response code="200">Caso a pesquisa seja realizada com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult BuscaDestinoPorId([FromQuery] int id)
    {
        var destino = _context.Destinos.FirstOrDefault(destino => destino.Id == id);
        if (destino == null) return NotFound();
        var destinoDto = _mapper.Map<ReadDestinoDto>(destino);
        return Ok(destinoDto);
    }

    /// <summary>
    /// Atualiza todos os campos de um destino
    /// </summary>
    /// <param name="id">Id do destino a ser atualizado</param>
    /// <param name="destinoDto">Dados necessários para atualizar o destino</param>
    /// <returns></returns>
    /// <response code="204">Caso a atualização seja realizada com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaDestinoPorId(int id, UpdateDestinoDto destinoDto)
    {
        var destino = _context.Destinos.FirstOrDefault(destino => destino.Id == id);
        if (destino == null) return NotFound();
        _mapper.Map(destinoDto, destino);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza apenas os campos solicitados de um destino
    /// </summary>
    /// <param name="id">Id do destino a ser atualizado</param>
    /// <param name="patch">Campo e valor a ser atualizado</param>
    /// <returns></returns>
    /// <response code="204">Caso o destino seja atualizado com sucesso</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaDestinoParcial(int id, JsonPatchDocument<UpdateDestinoDto> patch)
    {
        var destino = _context.Destinos.FirstOrDefault(destino => destino.Id == id);
        if (destino == null) return NotFound();
        var destinoParaAtualizar = _mapper.Map<UpdateDestinoDto>(destino);
        patch.ApplyTo(destinoParaAtualizar, ModelState);

        if (!TryValidateModel(destinoParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(destinoParaAtualizar, destino);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um destino a partir do Id fornecido
    /// </summary>
    /// <param name="id">Id do destino a ser deletado</param>
    /// <returns></returns>
    /// <response code="204">Caso o destino seja deletado com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaDestinoPorId(int id)
    {
        var destino = _context.Destinos.FirstOrDefault(destino => destino.Id == id);
        if (destino == null) return NotFound();
        _context.Remove(destino);
        _context.SaveChanges();
        return NoContent();
    }
}