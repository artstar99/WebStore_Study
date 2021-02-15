using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMvcSitemap;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Controllers.Api
{
    public class SiteMap : Controller
    {
        public IActionResult Index([FromServices] IProductData productData)
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("Shop", "Catalog")),
                new SitemapNode(Url.Action("Index", "Blogs")),
                new SitemapNode(Url.Action("BlogSingle", "Blogs")),
            };

            nodes.AddRange(productData.GetSections().Select(s=>new SitemapNode(Url.Action("Shop", "Catalog", new {SectionId=s.Id}))));

            foreach (var brand in productData.GetBrands())
            {
                nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new{brand.Id})));
            }

            foreach (var product in productData.GetProducts())
            {
                nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new { product.Id })));
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
