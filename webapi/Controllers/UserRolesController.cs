using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

public class UserRolesController : ControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRoleToUser(string userid, string roleName)
    {

        var user = await _userManager.FindByIdAsync(userid);
        var role = await _roleManager.RoleExistsAsync(roleName);
        if (user == null || !role)
            return NotFound("User or Role not found");

        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (result.Succeeded)
        {
            return Ok($"Role {roleName} assigned to user {userid}.");
        }
        return BadRequest(result.Errors);
    }
}