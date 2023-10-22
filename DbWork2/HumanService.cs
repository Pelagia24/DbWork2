using DbWork2.Rep;

namespace DbWork2;

public interface IHumanService
{
    Task InsertHumanAsync(Human human);
    Task DeleteHumanAsync(int id);
    Task<Human[]> GetHumansAsync(int id);
}

public class HumanService : IHumanService
{
    private readonly IHumanRepository _humanRepository;

    public HumanService(IHumanRepository humanRepository)
    {
        _humanRepository = humanRepository;
    }

    public async Task InsertHumanAsync(Human human)
    {
        await _humanRepository.InsertHumanAsync(human);
    }

    public async Task DeleteHumanAsync(int id)
    {
        await _humanRepository.DeleteHumanAsync(id);
    }

    public async Task<Human[]> GetHumansAsync(int id)
    {
        return await _humanRepository.GetHumansAsync(id);
    }
}