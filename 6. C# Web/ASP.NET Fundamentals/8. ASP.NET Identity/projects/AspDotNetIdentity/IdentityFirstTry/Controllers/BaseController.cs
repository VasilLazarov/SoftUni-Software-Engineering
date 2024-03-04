using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFirstTry.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
