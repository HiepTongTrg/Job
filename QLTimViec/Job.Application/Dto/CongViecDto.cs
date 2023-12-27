using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Dto
{
    public class CongViecDto
    {
        public int ID { get; set; }
        public int NhaTuyenDungID { get; set; }
        public DateTime NgayDang { get; set; }
        public string TenCongViec { get; set; }
        public double Luong { get; set; }
        public string MoTa { get; set; }
        public string LoaiCV { get; set; }
        public string Avatar { get; set; }
    }
}
