using AutoMapper;
using EMSApp.Application;
using EMSApp.Domain.Exceptions;
using EMSApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMSApp.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;
    public UsersController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Roles ="admin,manager")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create(
        [FromBody] CreateUserRequest req, 
        CancellationToken ct)
    {
        var user = await _service.CreateAsync(req.Email, req.Username, req.PasswordHash, req.DepartmentId, ct);
        var dto = _mapper.Map<UserDto>(user);
        return CreatedAtAction(
            nameof(GetById), 
            new { id = user.Id }, 
            dto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(string id, CancellationToken ct)
    {
        var user = await _service.GetByIdAsync(id, ct);
        if(user is null) return NotFound();

        var dto = _mapper.Map<UserDto>(user);
        return dto;
    }

    [HttpGet("{id}/profile")]
    public async Task<ActionResult<UserProfileDto>> GetProfile(string id, CancellationToken ct)
    {
        var user = await _service.GetByIdAsync(id, ct);
        if (user is null) return NotFound();
        return _mapper.Map<UserProfileDto>(user.Profile);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> ListByDept(
        [FromQuery] string? departmentId,
        CancellationToken ct)
    {
        var users = departmentId is null
            ? await _service.GetAllAsync(ct)
            : await _service.ListByDepartmentAsync(departmentId, ct);

        var dtos = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(dtos);
    }

    [Authorize(Roles ="admin,manager")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserRequest req, CancellationToken ct)
    {
        var user = await _service.GetByIdAsync(id, ct);
        if (user is null) return NotFound();

        if(req.PasswordHash is not null) user.UpdatePassword(req.PasswordHash);
        if(req.DepartmentId is not null) user.UpdateDepartment(req.DepartmentId);

        await _service.UpdateAsync(user, ct);
        return NoContent();
    }

    [Authorize(Roles = "admin,manager")]
    [HttpPut("{id}/profile")]
    public async Task<IActionResult> UpdateProfile(
        string id,
        [FromBody] UpdateUserProfileRequest req,
        CancellationToken ct)
    {
        var user = await _service.GetByIdAsync(id, ct);
        if (user is null) return NotFound();

        /*if (req.Name is not null) user.Profile.UpdateName(req.Name);
        if (req.JobTitle is not null) user.Profile.UpdateJobTitle(req.JobTitle);
        // …and so on…*/

        await _service.UpdateAsync(user, ct);
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
