using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TourAgency.Helpers
{
    public static class PageHelper
    {
        public static string LinksBuilder(this HtmlHelper html, int currentPage, int totalPages, Func<int,string> pageUrl)
        {
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            StringBuilder result = new StringBuilder();

            if (currentPage > 1)
            {
                TagBuilder tagLi = new TagBuilder("li");
                TagBuilder tagA = new TagBuilder("a");
                tagA.MergeAttribute("href", pageUrl(1));
                tagA.InnerHtml = "First";
                tagLi.InnerHtml = tagA.ToString();
                result.AppendLine(tagLi.ToString());
                tagLi = new TagBuilder("li");
                tagA = new TagBuilder("a");
                tagA.MergeAttribute("href", pageUrl(currentPage-1));
                tagA.InnerHtml = "Prev";
                tagLi.InnerHtml = tagA.ToString();
                result.AppendLine(tagLi.ToString());
            }

            for (int i = startPage, count = 0; i <= endPage; i++)
            {
                TagBuilder tagLi = new TagBuilder("li");
                TagBuilder tagA = new TagBuilder("a");
                tagA.MergeAttribute("href", pageUrl(i));
                tagA.InnerHtml = i.ToString();
                if(i == currentPage)
                    tagLi.AddCssClass("active");
                tagLi.InnerHtml = tagA.ToString();
                result.AppendLine(tagLi.ToString());
            }

            if (currentPage < totalPages)
            {
                TagBuilder tagLi = new TagBuilder("li");
                TagBuilder tagA = new TagBuilder("a");
                tagA.MergeAttribute("href", pageUrl(currentPage + 1));
                tagA.InnerHtml = "Next";
                tagLi.InnerHtml = tagA.ToString();
                result.AppendLine(tagLi.ToString());
                tagLi = new TagBuilder("li");
                tagA = new TagBuilder("a");
                tagA.MergeAttribute("href", pageUrl(totalPages));
                tagA.InnerHtml = "Last";
                tagLi.InnerHtml = tagA.ToString();
                result.AppendLine(tagLi.ToString());
                
            }

            TagBuilder tagDiv = new TagBuilder("div");
            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination");
            tagUl.InnerHtml = result.ToString();
            tagDiv.InnerHtml = tagUl.ToString();
            return tagDiv.ToString();
        }
    }
}