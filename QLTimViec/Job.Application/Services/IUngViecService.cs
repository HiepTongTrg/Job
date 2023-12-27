using Job.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Services
{
    public interface IUngViecService
    {
        List<UngVienDto> GetAll();
        UngVienDto Get(int id);
        bool Add(UngVienDto ungVien);
        bool Update(UngVienDto ungVien);
        bool Delete(int id);
    }
}
