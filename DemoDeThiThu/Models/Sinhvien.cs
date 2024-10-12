using System;
using System.Collections.Generic;

namespace DemoDeThiThu.Models
{
    public partial class Sinhvien
    {
        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public int? Tuoi { get; set; }
        public string? Nganh { get; set; }
        public string? MaLop { get; set; }

        public virtual Lophoc? MaLopNavigation { get; set; }
    }
}
