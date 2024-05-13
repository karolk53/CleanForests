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

    public void CreateNewClub(Club club)
    {
        throw new NotImplementedException();
    }
}