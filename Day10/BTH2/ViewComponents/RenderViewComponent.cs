using Microsoft.AspNetCore.Mvc;
using BTH2.Models;

namespace BTH2.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        // Danh sách menu
        private readonly List<MenuItem> MenuItems;

        // Constructor
        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    Id = 1,
                    Name = "Branches",
                    Link = "/Branches/List"
                },

                new MenuItem()
                {
                    Id = 2,
                    Name = "Students",
                    Link = "/Student/Index"
                },

                new MenuItem()
                {
                    Id = 3,
                    Name = "Subjects",
                    Link = "/Subjects/List"
                },

                new MenuItem()
                {
                    Id = 4,
                    Name = "Courses",
                    Link = "/Courses/List"
                }
            };
        }

        // Phương thức được gọi khi render ViewComponent
        public IViewComponentResult Invoke()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}