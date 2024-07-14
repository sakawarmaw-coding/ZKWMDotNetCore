using Microsoft.AspNetCore.Mvc;

namespace ZKWMDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {

        public IActionResult ExampleChart()
        {
            return View();
        }

        public IActionResult InterpolationLineChart()
        {
            return View();
        }

    }
}
