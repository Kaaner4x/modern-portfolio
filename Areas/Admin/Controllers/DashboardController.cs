using Microsoft.AspNetCore.Mvc;

namespace ModernPortfolio.Areas.Admin.Controllers
{
    public class DashboardController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
