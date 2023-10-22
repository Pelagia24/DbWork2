using DbWork2;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class HumanController : ControllerBase
{
    private readonly IHumanService _humanService;

    public HumanController(IHumanService humanService)
    {
        _humanService = humanService;
    }

    [HttpPost("Insert")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Insert(Human human)
    {
        try
        {
            await _humanService.InsertHumanAsync(human);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPost("Delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _humanService.DeleteHumanAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPost("Get")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var humans = await _humanService.GetHumansAsync(id);
            return Ok(humans);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}