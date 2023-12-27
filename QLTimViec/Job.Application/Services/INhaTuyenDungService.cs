using Job.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Services
{
    public interface INhaTuyenDungService
    {
        List<NhaTuyenDungDto> GetAll();
        NhaTuyenDungDto Get(int id);
        bool Add(NhaTuyenDungDto nhaTuyenDung);
        bool Update(NhaTuyenDungDto nhaTuyenDung);
        bool Delete(int id);
    }
}
