using CrudToAlgo.Domain.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/submissoes")]
public class SubmissoesController : ControllerBase
{
    private readonly ISubmissionService _submissionService;
    public SubmissoesController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubmissionDto dto)
    {
        var submissionId = await _submissionService.CreateAndRunAsync(dto);
        return Accepted(new { submissionId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _submissionService.GetStatusAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}
