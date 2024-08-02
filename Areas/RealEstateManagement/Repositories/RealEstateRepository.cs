using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Models;

namespace restate.RealEstateManagement.Repositories;

public class RealEstateRepository : IRepository<RealEstate>
{
    private readonly AppDbContext _context;

    public RealEstateRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<RealEstate>> FindAll()
    {
        return await _context.RealEstates.ToListAsync();
    }
    
    public async Task<RealEstate?> FindById(int id)
    {
        return await _context.RealEstates.FindAsync(id);
    }

    public async Task Create(RealEstate realEstate)
    {
        _context.RealEstates.Add(realEstate);
        await _context.SaveChangesAsync();
    }

    public async Task Update(RealEstate realEstate)
    {
        _context.Entry(realEstate).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}