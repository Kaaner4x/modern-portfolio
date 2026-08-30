using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModernPortfolio.Extensions;

public static class HtmlHelper
{
    public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
    {
        var routeData = htmlHelper.ViewContext.RouteData;
        var currentController = routeData.Values["controller"]?.ToString();
        var currentAction = routeData.Values["action"]?.ToString();

        var result = (string.Equals(controller, currentController, StringComparison.OrdinalIgnoreCase) &&
                      string.Equals(action, currentAction, StringComparison.OrdinalIgnoreCase)) ? "active" : "";

        return result;
    }
}
