using Microsoft.AspNetCore.Mvc;

namespace LogiCommerce.SharedKernel.BaseClasses;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(BaseServiceResponse<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}