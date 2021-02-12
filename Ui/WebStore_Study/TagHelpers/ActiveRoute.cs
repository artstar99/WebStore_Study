using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebStore_Study.TagHelpers
{
    [HtmlTargetElement(Attributes = attributeName)]
    public class ActiveRoute : TagHelper
    {
        private const string attributeName = "taghelper-is-active-route";
        private const string ignoreAction = "taghelper-ignore-action";

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public Dictionary<string, string> RoutesValues { get; set; } = new(StringComparer.OrdinalIgnoreCase);

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ignore = output.Attributes.ContainsName(ignoreAction);
            
            if (IsActive(ignore))
                MakeActive(output);

            output.Attributes.RemoveAll(attributeName);
        }

        private bool IsActive( bool ignore)
        {
            var routeVaLues = ViewContext.RouteData.Values;
            var currentController = routeVaLues["Controller"]?.ToString();
            var currentAction = routeVaLues["Action"]?.ToString();

            var comparisonOpt = StringComparison.OrdinalIgnoreCase;

            if (!string.IsNullOrEmpty(Controller) && !string.Equals(currentController, Controller, comparisonOpt))
                return false;

            if (!ignore && !string.IsNullOrEmpty(Action) && !string.Equals(currentAction, Action, comparisonOpt))
                return false;

            foreach (var (key, value) in routeVaLues)
                if (!routeVaLues.ContainsKey(key) || routeVaLues[key]?.ToString() != value)
                    return false;

            return true;
        }
        private void MakeActive(TagHelperOutput output)
        {
            var classAttribute = output.Attributes.FirstOrDefault(atr => atr.Name == "class");

            if (classAttribute is null)
                output.Attributes.Add("class", "active");
            else
            {
                if (classAttribute.Value.ToString()?.Contains("active") ?? false)
                    return;
                output.Attributes.SetAttribute("class", classAttribute.Value + "active");


            }

        }

    }
}
