using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Domain.Entities
{
    public class XinViec
    {
        public int ID { get; set; }
        public int UngVienID { get; set; }
        public int CongViecID { get; set; }
        public string CV { get; set; }
        public int TrangThai { get; set; }
        public string MoTa { get; set; }
        public UngVien UngVien { get; set; }
        public CongViec CongViec { get; set; }
    }
}
