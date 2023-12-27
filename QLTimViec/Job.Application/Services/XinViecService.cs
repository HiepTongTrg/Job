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
    public class XinViecService:IXinViecService
    {
        private readonly IXinViecRepo _xinViecRepo;
        private readonly IMapper _mapper;
        public XinViecService(IXinViecRepo xinViecRepo, IMapper mapper)
        {
            _xinViecRepo = xinViecRepo;
            _mapper = mapper;
        }
        public List<XinViecDto> GetAll()
        {
            return _mapper.Map<List<XinViecDto>>(_xinViecRepo.GetAll());
        }
        public XinViecDto Get(int id)
        {
            return _mapper.Map<XinViecDto>(_xinViecRepo.Get(id));
        }
        public bool Add(XinViecDto xinViec)
        {
            return _xinViecRepo.Add(_mapper.Map<XinViec>(xinViec));
        }
        public bool Update(XinViecDto xinViec)
        {
            return _xinViecRepo.Update(_mapper.Map<XinViec>(xinViec));
        }
        public bool Delete(int id)
        {
            return _xinViecRepo.Delete(id);
        }
    }
}
