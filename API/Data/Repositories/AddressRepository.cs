using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AddressRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateNewAddress(Address address)
    {
        await _context.Addresses.AddAsync(address);
    }
}