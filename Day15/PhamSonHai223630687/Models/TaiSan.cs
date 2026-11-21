using System;
using System.Collections.Generic;

namespace PhamSonHai223630687.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    public string TenTs { get; set; } = null!;

    public decimal? NguyenGia { get; set; }

    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
