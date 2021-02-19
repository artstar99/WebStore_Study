using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Controllers
{
    public class AjaxTestController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> GetJson(int? id, string msg, int delay = 1000)
        {
            await Task.Delay(delay);
            return Json(new
            {
                Message = $"Response (id:{id ?? -1}): {msg ?? "<null>"}",
                ServerTime = DateTime.Now
            });
        }

        public async Task<IActionResult> GetHtml(int? id, string msg, int delay = 1000)
        {
            await Task.Delay(delay);

            return PartialView("Partial/DataView", new AjaxTestDataViewModel()
            {
                Id = id,
                Message = msg,
                ServerTime = DateTime.Now,
            });
        }
    }
}
