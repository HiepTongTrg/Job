using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Domain.Entities
{
    public class NhaTuyenDung
    {
        public int ID { get; set; }
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public ICollection<CongViec> congViecs { get; set; }
    }
}
