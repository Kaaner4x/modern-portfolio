using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ModernPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public abstract class BaseAdminController : Controller
    {
    }
}
