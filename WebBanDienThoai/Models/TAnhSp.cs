﻿using System;
using System.Collections.Generic;

namespace WebBanDienThoai.Models;

public partial class TAnhSp
{
    public string MaSp { get; set; } = null!;

    public string TenFileAnh { get; set; } = null!;

    public virtual TDanhMucSp MaSpNavigation { get; set; } = null!;
}