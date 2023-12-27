using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Domain.Entities
{
    public class CongViec
    {
        public int ID { get; set; }
        public int NhaTuyenDungID { get; set; }
        public DateTime NgayDang { get; set; }
        public string TenCongViec { get; set; }
        public double Luong { get; set; }
        public string MoTa { get; set; }
        public string LoaiCV { get; set; }
        public string Avatar { get; set; }
        public NhaTuyenDung NhaTuyenDung { get; set; }
        public ICollection<XinViec> xinViecs { get; set; }
    }
}
