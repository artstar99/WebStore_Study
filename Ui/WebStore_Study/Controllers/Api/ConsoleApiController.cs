using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.Controllers.Api
{
    [Route("api/console")]
    [ApiController]
    public class ConsoleApiController : ControllerBase
    {
        [HttpGet("clear")]
        public void Clear() => Console.Clear();

        [HttpGet("writeline/{str}")]
        public void WriteLine(string str) => Console.WriteLine(str);

        [HttpGet("newline")]
        public void NewLine() => Console.Write("\n");
    }
}
