using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHangHoa { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHangHoa { get; set; }
        public string MoTa {  get; set; }
        [Range (0, double.MaxValue)]
        public double Gia { get; set; }
        public byte GiamGia { get; set; }
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai loai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public HangHoa()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
