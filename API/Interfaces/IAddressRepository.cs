using API.Entities;

namespace API.Interfaces;

public interface IAddressRepository
{
    Task CreateNewAddress(Address address);
}