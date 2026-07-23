using BlogManager_VoLeDinhKhanh.Models;
using Microsoft.AspNetCore.Mvc;

public class LabController : Controller
{
    public IActionResult Index()
    {
        var baiViet = new List<Post>
        {
            new Post {Id = 1, Title = "C# cơ bản", Author = "An", ViewCount = 120, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-10)},
            new Post {Id = 2, Title = "MVC nhập môn", Author = "Bình", ViewCount = 87, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-8)},
            new Post {Id = 3, Title = "EF Core nâng cao", Author = "Trang", ViewCount = 205, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-5)},
            new Post {Id = 4, Title = "Razor Pages", Author = "Minh", ViewCount = 54, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-3)},
            new Post {Id = 5, Title = "API với ASP.NET", Author = "Lan", ViewCount = 178, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-1)},
            new Post {Id = 6, Title = "Triển khai Azure", Author = "Hùng", ViewCount = 33, IsPublished = true, PublishedAt = DateTime.Now.AddDays(-2)},
        };

        var baiVietDaXuatBan = baiViet
            .Where(p => p.IsPublished)
            .OrderByDescending(p => p.ViewCount)
            .ToList();

        ViewBag.SoDaXuatBan = baiVietDaXuatBan.Count;
        ViewBag.BaiVietDaXuatBan = baiVietDaXuatBan;
        ViewBag.TongLuotXem = baiViet.Sum(p => p.ViewCount);
        ViewBag.BaiVietNhieuLuotXemNhat = baiViet
            .OrderByDescending(p => p.ViewCount)
            .FirstOrDefault();
        ViewBag.Top3BaiViet = baiViet
            .OrderByDescending(p => p.ViewCount)
            .Take(3)
            .ToList();

        return View();
    }
}