using Microsoft.AspNetCore.Mvc;

namespace ria.smc.associates.UI.Components.Layout;
public class HeaderViewComponent : ViewComponent
{ 
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("../Layout/Header");
    }
}