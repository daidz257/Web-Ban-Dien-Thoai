using WebBanDienThoai.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Models.Authentication;

namespace WebBanDienThoai.Controllers
{
    public class AccessController : Controller
    {
        QlbanDienThoaiContext db = new QlbanDienThoaiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName")==null)
            {
                return View();
            }
            else {
            return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TUser user) {
            if(HttpContext.Session.GetString("UserName")==null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if(u!=null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    if (u.LoaiUser == 1)
                    {
                        return RedirectToAction("DanhMucSanPham", "HomeAdmin", new { area = "Admin" });

                    }
                    else if (u.LoaiUser == 0) return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(TUser model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên đăng nhập đã tồn tại trong cơ sở dữ liệu hay chưa
                var existingUser = db.TUsers.Where(u => u.Username.Equals(model.Username)).FirstOrDefault();
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                    return View();
                }

                // Lưu thông tin đăng ký của người dùng vào cơ sở dữ liệu
                if (ModelState.IsValid)
                {
                    model.LoaiUser = 0;
                    db.TUsers.Add(model);
                    db.SaveChanges();
                }
                // Đăng nhập ngay sau khi đăng ký thành công
                HttpContext.Session.SetString("UserName", model.Username.ToString());
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
