using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClubController
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ClubController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateNewClub(ClubCreateDto createDto)
    {
        var club = _mapper.Map<Club>(createDto);
        var address = _mapper.Map<Address>(createDto);

        return null;
    }
}