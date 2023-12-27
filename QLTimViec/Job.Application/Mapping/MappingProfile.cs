using AutoMapper;
using Job.Application.Dto;
using Job.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CongViec, CongViecDto>().ReverseMap();
            CreateMap<NhaTuyenDung, NhaTuyenDungDto>().ReverseMap();
            CreateMap<UngVien, UngVienDto>().ReverseMap();
            CreateMap<XinViec, XinViecDto>().ReverseMap();
        }
    }
}
