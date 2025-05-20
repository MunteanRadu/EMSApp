using AutoMapper;
using EMSApp.Application;
using EMSApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EMSApp.Api;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly IAssignmentService _service;
    private readonly IMapper _mapper;
    public AssignmentsController(IAssignmentService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Roles = "admin,manager")]
    [HttpPost]
    public async Task<ActionResult<AssignmentDto>> Create(
        [FromBody] CreateAssignmentRequest req,
        CancellationToken ct)
    {
        var a = await _service.CreateAsync(
            req.Title,
            req.Description,
            req.DueDate,
            req.AssignedToId,
            ct);

        var dto = _mapper.Map<AssignmentDto>(a);
        return CreatedAtAction(
            nameof(GetById),
            new { id = a.Id },
            dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentDto>> GetById(string id, CancellationToken ct)
    {
        var a = await _service.GetByIdAsync(id, ct);
        if (a is null) return NotFound();
        return _mapper.Map<AssignmentDto>(a);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentDto>>> List(
        CancellationToken ct)
    {
        var list = await _service.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<AssignmentDto>>(list));
    }

    [HttpGet("listBySomething")]
    public async Task<ActionResult<IEnumerable<AssignmentDto>>> ListByAssignee(
        [FromQuery(Name = "asignee")] string? userId,
        [FromQuery(Name = "overdueAsOf")] DateTime? overdueAsOf,
        [FromQuery(Name = "status")] AssignmentStatus? status,
        CancellationToken ct)
    {
        IReadOnlyList<Assignment> list;

        if (userId is not null)
            list = await _service.ListByAsigneeAsync(userId, ct);
        else if(overdueAsOf is not null)
            list = await _service.ListByOverdueAsync(overdueAsOf.Value, ct);
        else if (status is not null)
            list = await _service.ListByStatusAsync(status.Value, ct);
        else
            return BadRequest("Must specify assignee, overdueAsOf or status");

        var dtos = list.Select(a => _mapper.Map<AssignmentDto>(a));
        return Ok(dtos);
    }

    [Authorize(Roles = "admin,manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        string id,
        [FromBody] UpdateAssignmentRequest req,
        CancellationToken ct)
    {
        var existing = await _service.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        //TODO fel de fel de updates

        await _service.UpdateAsync(existing, ct);
        return NoContent();
    }

    [Authorize(Roles = "admin,manager")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}
