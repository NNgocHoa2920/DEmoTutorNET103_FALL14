using System;
using System.Collections.Generic;

namespace DemoDeThiThu.Models
{
    public partial class Lophoc
    {
        public Lophoc()
        {
            Sinhviens = new HashSet<Sinhvien>();
        }

        public string MaLop { get; set; } = null!;
        public string? TenLop { get; set; }
        public string? Khoa { get; set; }

        public virtual ICollection<Sinhvien> Sinhviens { get; set; }
    }
}
