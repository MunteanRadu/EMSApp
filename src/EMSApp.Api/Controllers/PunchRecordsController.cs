using AutoMapper;
using EMSApp.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMSApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PunchRecordsController : ControllerBase
{
    private readonly IPunchRecordService _service;
    private readonly IMapper _mapper;

    public PunchRecordsController(IPunchRecordService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<PunchRecordDto>> Create(
        [FromBody] CreatePunchRecordRequest req,
        CancellationToken ct)
    {
        var pr = await _service.CreateAsync(
            req.UserId, req.Date, req.TimeIn, ct);

        var dto = _mapper.Map<PunchRecordDto>(pr);
        return CreatedAtAction(
            nameof(GetById),
            new { id = pr.Id },
            dto);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<PunchRecordDto>> GetById(
        string id,
        CancellationToken ct)
    {
        var pr = await _service.GetByIdAsync(id, ct);
        if (pr is null) return NotFound();
        return _mapper.Map<PunchRecordDto>(pr);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PunchRecordDto>>> ListByUser(
        [FromQuery] string? userId,
        CancellationToken ct)
    {
        var list = userId is not null
            ? await _service.ListByUserAsync(userId, ct)
            : await _service.GetAllAsync(ct);

        return Ok(_mapper.Map<IEnumerable<PunchRecordDto>>(list));
    }

    [Authorize(Roles = "admin,manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] UpdatePunchRecordRequest req,
        CancellationToken ct)
    {
        var pr = await _service.GetByIdAsync(id, ct);
        if (pr is null) return NotFound();

        if (req.TimeOut is not null) pr.PunchOut(req.TimeOut.Value);

        await _service.UpdateAsync(pr, ct);
        return NoContent();
    }

    [Authorize(Roles = "admin,manager")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        string id,
        CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}
