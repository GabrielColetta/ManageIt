using Microsoft.AspNetCore.Mvc;
using ManageIt.Domain.Contracts.Applications;
using ManageIt.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ManageIt.Api.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        public HomeController(IHomeApplication application)
        {
            _application = application;
        }

        private readonly IHomeApplication _application;

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = _application.Index();
                return Ok(result);
            }
            catch (BusinessException ex)
            {
                if (ex.statusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(ex.ErrorDescription);
                }
                return BadRequest(ex.ErrorDescription);
            }
        }
    }
}
