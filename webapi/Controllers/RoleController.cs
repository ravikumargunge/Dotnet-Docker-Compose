using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class RoleController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded)
        {
            return Ok($"Role {roleName} created successfully.");
        }
        return BadRequest(result.Errors);
    }
}