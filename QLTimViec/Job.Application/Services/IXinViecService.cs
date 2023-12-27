using Job.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Services
{
    public interface IXinViecService
    {
        List<XinViecDto> GetAll();
        XinViecDto Get(int id);
        bool Add(XinViecDto ungVien);
        bool Update(XinViecDto ungVien);
        bool Delete(int id);
    }
}
