using Microsoft.EntityFrameworkCore;
using restate.db;
using restate.RealEstateManagement.Models;

namespace restate.RealEstateManagement.Repositories;

public class EstateUnitRepository : IRepository<EstateUnit>
{
    private readonly AppDbContext _context;

    public EstateUnitRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<EstateUnit>> FindAll()
    {
        return await _context.EstateUnits.ToListAsync();
    }
    
    public async Task<EstateUnit?> FindById(int id)
    {
        return await _context.EstateUnits.FindAsync(id);
    }

    public async Task Create(EstateUnit estateUnit)
    {
        _context.EstateUnits.Add(estateUnit);
        await _context.SaveChangesAsync();
    }

    public async Task Update(EstateUnit estateUnit)
    {
        _context.Entry(estateUnit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}