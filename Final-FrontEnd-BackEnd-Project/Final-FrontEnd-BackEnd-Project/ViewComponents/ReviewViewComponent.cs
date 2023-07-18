using Final_FrontEnd_BackEnd_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_FrontEnd_BackEnd_Project.ViewComponents
{
    public class ReviewViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Review model = new()
            {

            };
            return await Task.FromResult(View(model));
        }
    }

}
