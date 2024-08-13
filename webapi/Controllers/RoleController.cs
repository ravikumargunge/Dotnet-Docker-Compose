using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

public class RoleController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<RoleController> _logger;


    public RoleController(RoleManager<IdentityRole> roleManager, ILogger<RoleController> logger)
    {
        _roleManager = roleManager;
        _logger = logger;
        _logger.LogInformation("RoleController Constructor Executed.");
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        _logger.LogInformation("Create Role Initiated.");
        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded)
        {
            _logger.LogInformation("Create Role Completed Successfully.");
            return Ok($"Role {roleName} created successfully.");
        }
        _logger.LogInformation($"Create Role failed with error {result.Errors}.");
        return BadRequest(result.Errors);
    }
}