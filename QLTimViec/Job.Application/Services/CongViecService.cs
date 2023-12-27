using AutoMapper;
using Job.Application.Dto;
using Job.Domain.Entities;
using Job.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Application.Services
{
    public class CongViecService:ICongViecService
    {
        private readonly ICongViecRepo _congViecRepo;
        private readonly IMapper _mapper;
        public CongViecService(ICongViecRepo congViecRepo, IMapper mapper)
        {
            _congViecRepo = congViecRepo;
            _mapper = mapper;
        }
        public List<CongViecDto> GetAll()
        {
            return _mapper.Map<List<CongViecDto>>(_congViecRepo.GetAll());
        }
        public CongViecDto Get(int id)
        {
            return _mapper.Map<CongViecDto>(_congViecRepo.Get(id));
        }
        public bool Add(CongViecDto congViec)
        {
            return _congViecRepo.Add(_mapper.Map<CongViec>(congViec));
        }
        public bool Update(CongViecDto congViec)
        {
            return _congViecRepo.Update(_mapper.Map<CongViec>(congViec));
        }
        public bool Delete(int id)
        {
            return _congViecRepo.Delete(id);
        }
    }
}
