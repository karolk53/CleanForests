using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClubController : BaseApiController
{
    private readonly IClubRepository _clubRepository;
    private readonly IMapper _mapper;

    public ClubController(IClubRepository clubRepository, IMapper mapper)
    {
        _clubRepository = clubRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateNewClub(ClubCreateDto createDto)
    {
        var club = _mapper.Map<Club>(createDto);
        var address = _mapper.Map<Address>(createDto);

        club.Address = address;

        await _clubRepository.CreateNewClub(club);

        if (await _clubRepository.SaveChangesAsync())
        {
            return Ok("Club created successfully");
        }

        return BadRequest("Failed to create a club");
    }
}