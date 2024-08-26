using DocumentService.Application.DTOs;
using DocumentService.Application.Interfaces;
using DocumentService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
    {
        var organizations = await _organizationService.GetAllOrganizationsAsync();
        return Ok(organizations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Organization>> GetOrganization(int id)
    {
        var organization = await _organizationService.GetOrganizationByIdAsync(id);
        if (organization == null)
        {
            return NotFound();
        }

        return Ok(organization);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Organization>> CreateOrganization(CreateOrganizationDto createOrganizationDto)
    {
        var organization = new Organization
        {
            Name = createOrganizationDto.Name,
        };
        await _organizationService.AddOrganizationAsync(organization);
        return CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organization);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrganization(int id, Organization organization)
    {
        if (id != organization.Id)
        {
            return BadRequest();
        }

        await _organizationService.UpdateOrganizationAsync(organization);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganization(int id)
    {
        await _organizationService.DeleteOrganizationAsync(id);
        return NoContent();
    }
}