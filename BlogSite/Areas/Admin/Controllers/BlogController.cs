using BlogSite.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value="Blog ID";
                worksheet.Cell(1, 2).Value="Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value=item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value=item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }

        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> list = new List<BlogModel>();
            using(var c=new Context())
            {
                list=c.Blogs.Select(x => new BlogModel
                {
                    Id=x.BlogId,BlogName=x.BlogTitle
                }).ToList();
            }
            return list;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
