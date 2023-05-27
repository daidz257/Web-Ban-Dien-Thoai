using WebBanDienThoai.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanDienThoai.Repository;

namespace WebBanDienThoai.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(X => X.Loai);
            return View(loaisp);
        }
    }
}
