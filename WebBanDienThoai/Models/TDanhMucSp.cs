using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models;

public partial class TDanhMucSp
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public string? MaHangSx { get; set; }

    public string? MaNuocSx { get; set; }

    public double? ThoiGianBaoHanh { get; set; }

    public string? GioiThieuSp { get; set; }

    public string? MaLoai { get; set; }

    public string? MaDt { get; set; }

    public string? AnhDaiDien { get; set; }

    public decimal? Gia { get; set; }

    public virtual TLoaiDt? MaDtNavigation { get; set; }

    public virtual THangSx? MaHangSxNavigation { get; set; }

    public virtual TLoaiSp? MaLoaiNavigation { get; set; }

    public virtual TQuocGium? MaNuocSxNavigation { get; set; }

    public virtual ICollection<TAnhSp> TAnhSps { get; set; } = new List<TAnhSp>();

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
