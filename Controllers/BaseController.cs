using LabProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public abstract class BaseController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    protected ApplicationUser CurrentUser { get; private set; }

    public BaseController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        CurrentUser = _userManager.GetUserAsync(User).Result;
    }
}
