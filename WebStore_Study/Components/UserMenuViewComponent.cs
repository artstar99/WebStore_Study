using Microsoft.AspNetCore.Mvc;

namespace WebStore_Study.Components
{
    public class UserMenuViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke() => User.Identity?.IsAuthenticated == true
            ? View("UserInfo")
            : View();
    }
}
