namespace WebBanDienThoai.Models

{
    public class CartItem
    {
        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien => SoLuong * Gia;
    }
}
