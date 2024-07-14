using Microsoft.AspNetCore.Mvc;

namespace ZKWMDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }
    }
}
