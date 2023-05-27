using WebBanDienThoai.Models;
namespace WebBanDienThoai.ViewModels
{
    public class HomeProductDetailViewModel
    {
        public TDanhMucSp danhMucSp { get; set; }
        public List<TAnhSp> anhSps { get; set;}
        public TLoaiDt loaiDt { get; set; }
        public TLoaiSp loaiSp { get; set; }
    }
}
