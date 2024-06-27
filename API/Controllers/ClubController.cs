using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClubController : BaseApiController
{
    private readonly IClubRepository _clubRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public ClubController(IClubRepository clubRepository, IAddressRepository addressRepository ,IMapper mapper)
    {
        _clubRepository = clubRepository;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateNewClub(ClubCreateDto createDto)
    {
        
        var address = _mapper.Map<Address>(createDto);
        var club = _mapper.Map<Club>(createDto);
        
        club.Address = address;
        
        await _clubRepository.CreateNewClub(club);

        if (await _clubRepository.SaveChangesAsync())
        {
            return Ok("Club created successfully");
        }

        return BadRequest("Failed to create a club");
    }
}