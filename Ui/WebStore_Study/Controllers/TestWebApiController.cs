using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Interfaces.TestApi;

namespace WebStore_Study.Controllers
{
    public class TestWebApiController : Controller
    {
        private readonly IValuesService valuesService;

        public TestWebApiController(IValuesService valuesService)
        {
            this.valuesService = valuesService;
        }
        public IActionResult Index()
        {
            var values = valuesService.Get();
            return View(values);
        }
    }
}
