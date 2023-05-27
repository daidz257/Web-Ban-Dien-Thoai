using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Models;
using WebBanDienThoai.Models.ProductModels;

namespace WebBanDienThoai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanDienThoaiContext db = new QlbanDienThoaiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               Gia = p.Gia
                           }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            var sanPham = (from p in db.TDanhMucSps where p.MaLoai == maLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               Gia = p.Gia
                           }).ToList();
            return sanPham;
        }
    }
}
