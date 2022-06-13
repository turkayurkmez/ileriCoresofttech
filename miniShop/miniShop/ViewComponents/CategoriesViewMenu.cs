using Microsoft.AspNetCore.Mvc;
using miniShop.Models;

namespace miniShop.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>
            {
                 new Category()
                 {
                     Id = 1,
                     Name = "Kozmetik"
                 },
                 new Category()
                 {
                     Id = 2,
                     Name = "Kişisel Bakım"
                 },
                 new Category()
                 {
                     Id = 3,
                     Name = "Giyim"
                 },
                 new Category()
                 {
                     Id = 4,
                     Name = "Alkollü İçecekler"
                 }
            };
            return View(categories);
        }
        

    }
}
