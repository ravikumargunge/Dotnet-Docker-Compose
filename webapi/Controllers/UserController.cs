using dataaccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace webapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.MobileNumber,
                PhoneNumber = registerModel.MobileNumber,
                Email = registerModel.Email,
                FullName = registerModel.Name,
                PinCode = registerModel.MobileNumber
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                return Ok($"User {registerModel.MobileNumber} registered successfully");
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUserByUserName(string PhoneNumber)
        {
            var user = new ApplicationUser
            {
                PhoneNumber = PhoneNumber,
                UserName= PhoneNumber
            };
            var result = await _userManager.FindByNameAsync(PhoneNumber);
            if (!string.IsNullOrEmpty(result?.Id.ToString()))
            {
                return Ok(result);
            }
            return NotFound("Not Found");
        }


        // [HttpGet]
        // [Route("Get")]
        // public IActionResult Get()
        // {
        //     var registrations = _applicationDbContext?.Registrations.ToList();
        //     if (registrations == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         return Ok(registrations.ToList());
        //     }

        // }

        // [HttpPost]
        // [Route("Post")]
        // public IActionResult Post(ApplicationUser registration)
        // {

        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }
        //     var result = _applicationDbContext.Registrations.Add(registration);
        //     _applicationDbContext.SaveChanges();
        //     return Ok(registration.Id);
        // }

    }
}
