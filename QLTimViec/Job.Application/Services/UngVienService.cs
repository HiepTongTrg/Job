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
    public class UngVienService:IUngViecService
    {
        private readonly IUngVienRepo _ungVienRepo;
        private readonly IMapper _mapper;
        public UngVienService(IUngVienRepo ungVienRepo, IMapper mapper)
        {
            _ungVienRepo = ungVienRepo;
            _mapper = mapper;
        }
        public List<UngVienDto> GetAll()
        {
            return _mapper.Map<List<UngVienDto>>(_ungVienRepo.GetAll());
        }
        public UngVienDto Get(int id)
        {
            return _mapper.Map<UngVienDto>(_ungVienRepo.Get(id));
        }
        public bool Add(UngVienDto ungVien)
        {
            return _ungVienRepo.Add(_mapper.Map<UngVien>(ungVien));
        }
        public bool Update(UngVienDto ungVien)
        {
            return _ungVienRepo.Update(_mapper.Map<UngVien>(ungVien));
        }
        public bool Delete(int id)
        {
            return _ungVienRepo.Delete(id);
        }
    }
}
