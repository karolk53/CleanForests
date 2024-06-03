using API.Entities;
using API.Interfaces;

namespace API.Data.Repositories;

public class ClubRepository : IClubRepository
{
    private readonly DataContext _context;

    public ClubRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateNewClub(Club club)
    {
        await _context.Clubs.AddAsync(club);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}