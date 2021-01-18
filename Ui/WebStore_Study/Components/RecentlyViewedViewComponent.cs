using Microsoft.AspNetCore.Mvc;

namespace WebStore_Study.Components
{
    public class RecentlyViewedViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
