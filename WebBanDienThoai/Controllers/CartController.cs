using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebBanDienThoai.ViewModels;
using WebBanDienThoai.Models;
using WebBanDienThoai.Helpers;

namespace WebBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        private readonly QlbanDienThoaiContext _context;
        public CartController(QlbanDienThoaiContext context)
        {
            _context = context;
        }
        public List<CartItem> Carts {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if(data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }


    
        public IActionResult AddToCart(string maSp, int SoLuong, string type = "Normal")
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaSp == maSp);
            if (item == null)
            {
                var hangHoa = _context.TDanhMucSps.SingleOrDefault(p=> p.MaSp==maSp);
                item = new CartItem
                {
                    MaSp = maSp,
                    TenSp = hangHoa.TenSp,
                    Gia = hangHoa.Gia.Value,
                    SoLuong = SoLuong,
                    AnhDaiDien = hangHoa.AnhDaiDien
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong+=SoLuong;
            }
            HttpContext.Session.Set("GioHang", myCart);
            if(type == "ajax")
            {
                return Json(new
                {
                    SoLuong = Carts.Sum(c=>c.SoLuong)
                });
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(Carts);
        }
    }
}
