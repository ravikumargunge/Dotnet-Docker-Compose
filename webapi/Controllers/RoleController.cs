using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

public class RoleController : ControllerBase
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ILogger<RoleController> _logger;


    public RoleController(RoleManager<ApplicationRole> roleManager, ILogger<RoleController> logger)
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
        var role = new ApplicationRole
        {
            Name = roleName
        };
        var result = await _roleManager.CreateAsync(role);
        if (result.Succeeded)
        {
            _logger.LogInformation("Create Role Completed Successfully.");
            return Ok($"Role {roleName} created successfully.");
        }
        _logger.LogInformation($"Create Role failed with error {result.Errors}.");
        return BadRequest(result.Errors);
    }
}