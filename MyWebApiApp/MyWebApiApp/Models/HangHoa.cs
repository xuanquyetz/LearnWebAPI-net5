using System;

namespace MyWebApiApp.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double Gia { get; set; }
        public string MoTa { get; set; }
        public byte GiaGiam {  get; set; }
        public int MaLoai { get; set; }
    }
    public class HangHoa: HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
    }
}
