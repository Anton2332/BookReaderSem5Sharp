using System.Net;
using DAL_Redis.Entities;
using DAL_Redis.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Redis.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryRepository _historyRepository;

    public HistoryController(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    [HttpGet("{userName}", Name = "GetHistory")]
    [ProducesResponseType(typeof(History), (int)HttpStatusCode.OK)]
    public IActionResult GetHistory(string userName)
    {
        var result = _historyRepository.GetHistory(userName);
        return Ok(result ?? new History(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(History), (int)HttpStatusCode.OK)]
    public IActionResult UpdateHistory([FromBody] History history)
    {
        return Ok(_historyRepository.UpdateHistory(history));
    }

    [HttpDelete("{userName}", Name = "DeleteHistory")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteHistory(string userName)
    {
        await _historyRepository.DeleteHistory(userName);
        return Ok();
    }
}