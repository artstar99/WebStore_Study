using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebStore_Study.Domain.ViewModels;

namespace WebStore_Study.TagHelpers
{
    public class Paging : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;
        public Paging(IUrlHelperFactory urlHelperFactory) => this.urlHelperFactory = urlHelperFactory;


        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new(StringComparer.OrdinalIgnoreCase);



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            for (int i = 1, totalCount = PageModel.TotalPages; i <= totalCount; i++)
            {
                ul.InnerHtml.AppendHtml(CreateElement(i, urlHelper));
            }

            output.Content.AppendHtml(ul);
        }

        private TagBuilder CreateElement(int pageNumber, IUrlHelper url)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");

            if (pageNumber == PageModel.Page)
                li.AddCssClass("active");
            else
            {
                PageUrlValues["page"] = pageNumber;
                a.Attributes["href"] = url.Action(PageAction, PageUrlValues);
            }


            a.InnerHtml.AppendHtml(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;

        }
    }
}
