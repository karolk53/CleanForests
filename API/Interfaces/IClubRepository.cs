using API.Entities;

namespace API.Interfaces;

public interface IClubRepository
{
    Task CreateNewClub(Club club);
    Task<bool> SaveChangesAsync();
}