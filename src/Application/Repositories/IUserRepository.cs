namespace Application.Repositories;

public interface IUserRepository
{
    Task<bool> UserExists(string email);
}