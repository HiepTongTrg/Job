using Job.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Services
{
    public interface ICongViecService
    {
        List<CongViecDto> GetAll();
        CongViecDto Get(int id);
        bool Add(CongViecDto congViec);
        bool Update(CongViecDto congViec);
        bool Delete(int id);
    }
}
