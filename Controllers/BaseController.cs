using LabProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Globalization;
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

    protected void SetCurrencySymbol()
    {
        var userLanguages = Request.Headers["Accept-Language"].ToString();
        var culture = userLanguages.Split(',').FirstOrDefault();
        try
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);

            if (cultureInfo.IsNeutralCulture)
            {
                culture = culture switch
                {
                    "en" => "en-US",
                    "fr" => "fr-FR",
                    "pl" => "pl-PL",
                    _ => "en-US"
                };
            }

            var regionInfo = new RegionInfo(culture);
            ViewBag.CurrencySymbol = regionInfo.CurrencySymbol;
            ViewBag.CurrentCulture = culture;

            var currencyCustomFormat = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.InvariantCulture.NumberFormat.Clone();
            currencyCustomFormat.CurrencyNegativePattern = 1;
            currencyCustomFormat.CurrencyGroupSeparator = " ";
            currencyCustomFormat.CurrencySymbol = ViewBag.CurrencySymbol == "£" ? "£ " : " " + ViewBag.CurrencySymbol;
            currencyCustomFormat.CurrencyPositivePattern = ViewBag.CurrencySymbol == "£" ? 0 : 1;
            currencyCustomFormat.CurrencyDecimalSeparator = culture == "pl-PL" ? "," : ".";
            

            ViewBag.CurrencyCustomFormat = currencyCustomFormat;
        }
        catch (CultureNotFoundException)
        {
            culture = "en-US";
            ViewBag.CurrencySymbol = new RegionInfo(culture).CurrencySymbol;
            ViewBag.CurrentCulture = culture;
        }
    }

}
