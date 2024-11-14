namespace Application.Repositories;

public interface IUserRepository
{
    Task<bool> UserExists(string username);
}