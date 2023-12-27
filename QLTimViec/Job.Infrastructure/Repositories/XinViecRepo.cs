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
    public class XinViecRepo:Repo<XinViec>,IXinViecRepo
    {
        public XinViecRepo(JobDbContext dbContext) : base(dbContext)
        {

        }
    }
}
