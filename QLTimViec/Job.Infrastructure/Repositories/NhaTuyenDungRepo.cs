using Job.Domain.Entities;
using Job.Domain.Repositories;
using Job.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Infrastructure.Repositories
{
    public class NhaTuyenDungRepo:Repo<NhaTuyenDung>,INhaTuyenDungRepo
    {
        public NhaTuyenDungRepo(JobDbContext dbContext) : base(dbContext)
        {

        }
    }
}
