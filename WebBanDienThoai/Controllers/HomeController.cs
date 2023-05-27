using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanDienThoai.Models;
using WebBanDienThoai.Models.Authentication;
using WebBanDienThoai.ViewModels;
using X.PagedList;

namespace WebBanDienThoai.Controllers
{
	public class HomeController : Controller
	{
		QlbanDienThoaiContext db = new QlbanDienThoaiContext();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		//[Authentication]

		public IActionResult Index()
		{
			var lstsanpham = db.TDanhMucSps.ToList();
			return View(lstsanpham);
		}
        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai).OrderBy(X => X.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
			ViewBag.maloai = maloai;
            return View(lst);
        }

        public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Shop(int? page)
		{
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(X => X.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

		public IActionResult ChiTietSanPham(string maSp)
		{
			var sanPham = db.TDanhMucSps.SingleOrDefault(x=>x.MaSp==maSp);
			var anhSanPham = db.TAnhSps.Where(x=>x.MaSp==maSp).ToList();
			ViewBag.anhSanPham = anhSanPham;
			return View(sanPham);
		}

		public IActionResult ProductDetail(string maSp)
		{
			var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
			var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
			var homeProductDetailViewModel = new HomeProductDetailViewModel
			{
				danhMucSp = sanPham,
				anhSps = anhSanPham
			};
            return View(homeProductDetailViewModel);
		}
        public IActionResult TimKiemSanPham(string searchString, int? page)
        {

            if (!string.IsNullOrEmpty(searchString))
            {
                var sanPhams = db.TDanhMucSps.Where(s => s.TenSp.Contains(searchString));
                /*var sanpham = db.TSanPhams.Include(x => x.TheLoai).Where(x => x.TenSp.ToUpper().Contains(searchString.ToUpper())).ToList();*/
                int pageSize = 9;
                int pageNumber = page == null || page < 0 ? 1 : page.Value; 
				var pagedSanPhams = sanPhams.ToPagedList(pageNumber, pageSize);
                return View("SanPhamTheoLoai", pagedSanPhams);
            }

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}