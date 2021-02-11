using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_Study.Controllers;
using Xunit;

namespace WebStore_Study.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsView()
        {
            // Arrange  - подготовка данных
            var controller = new HomeController();

            // Act      - выполнение действия
            var result = controller.Index();

            // Assert   - проверка результатов

            Assert.IsType<ViewResult>(result);
          
        }
    }
}
