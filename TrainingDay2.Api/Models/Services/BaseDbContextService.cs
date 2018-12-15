using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay2.Api.Models.Entities;

namespace TrainingDay2.Api.Models.Services
{
    public class BaseDbContextService
    {

        protected TrainingContext DbContext { get; set; }

        public BaseDbContextService(TrainingContext trainingContext)
        {
            this.DbContext = trainingContext;
        }

    }
}
