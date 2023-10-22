using DbWork2;
using Microsoft.EntityFrameworkCore;

namespace DbWork2.Rep;

public interface IHumanRepository
{
    Task InsertHumanAsync(Human human);
    Task DeleteHumanAsync(int id);
    Task<Human[]> GetHumansAsync(int id);
}

public class HumanRepository : IHumanRepository
{
    private readonly Context _context;

    public HumanRepository(Context context)
    {
        _context = context;
    }

    public async Task InsertHumanAsync(Human human)
    {
        _context.Humans.Add(human);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHumanAsync(int id)
    {
        var human = await _context.Humans.FindAsync(id);
        if (human != null)
        {
            _context.Humans.Remove(human);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Human[]> GetHumansAsync(int id)
    {
        if (id == 0)
        {
            return await _context.Humans.ToArrayAsync();
        }
        else
        {
            return new[] { await _context.Humans.FindAsync(id) };
        }
    }
}