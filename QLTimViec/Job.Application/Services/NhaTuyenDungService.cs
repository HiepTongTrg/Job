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
    public class NhaTuyenDungService:INhaTuyenDungService
    {
        private readonly INhaTuyenDungRepo _nhaTuyenDungRepo;
        private readonly IMapper _mapper;
        public NhaTuyenDungService(INhaTuyenDungRepo nhaTuyenDungRepo, IMapper mapper)
        {
            _nhaTuyenDungRepo = nhaTuyenDungRepo; 
            _mapper = mapper;
        }
        public List<NhaTuyenDungDto> GetAll()
        {
            return _mapper.Map<List<NhaTuyenDungDto>>(_nhaTuyenDungRepo.GetAll());
        }
        public NhaTuyenDungDto Get(int id)
        {
            return _mapper.Map<NhaTuyenDungDto>(_nhaTuyenDungRepo.Get(id));
        }
        public bool Add(NhaTuyenDungDto nhaTuyenDung)
        {
            return _nhaTuyenDungRepo.Add(_mapper.Map<NhaTuyenDung>(nhaTuyenDung));
        }
        public bool Update(NhaTuyenDungDto nhaTuyenDung)
        {
            return _nhaTuyenDungRepo.Update(_mapper.Map<NhaTuyenDung>(nhaTuyenDung));
        }
        public bool Delete(int id)
        {
            return _nhaTuyenDungRepo.Delete(id);
        }
    }
}
