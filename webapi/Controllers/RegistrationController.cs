using dataaccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace webapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        public readonly ApplicationDbContext _applicationDbContext;

        public RegistrationController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var registrations = _applicationDbContext?.Registrations.ToList();
            if (registrations == null)
            {
                return NotFound();
            }
            else
            {
                return (IActionResult)registrations;
            }

        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(Registration registration)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }   
            var result = _applicationDbContext.Registrations.Add(registration);
            _applicationDbContext.SaveChanges();
            return Ok(registration.Id);
        }

    }
}
