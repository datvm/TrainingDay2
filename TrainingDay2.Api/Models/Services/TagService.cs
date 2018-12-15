using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay2.Api.Models.Entities;
using TrainingDay2.Api.Models.ViewModels;

namespace TrainingDay2.Api.Models.Services
{

    public interface ITagService
    {
        Task<IEnumerable<TagBasicViewModel>> SearchAsync(string keyword);
    }

    public class TagService : BaseDbContextService
    {
        public TagService(TrainingContext trainingContext) : base(trainingContext)
        {
        }

        public async Task<IEnumerable<TagBasicViewModel>> SearchAsync(string keyword)
        {
            var noTrackingQuery = this.DbContext.Tag
                .AsNoTracking();

            var startsWithQuery = noTrackingQuery
                .Where(q => q.Name.StartsWith(keyword))
                .OrderBy(q => q.Name);

            var containsQuery = noTrackingQuery
                .Where(q => q.Name.Contains(keyword))
                .OrderBy(q => q.Name);
            
            var query = startsWithQuery.Union(containsQuery);

            var result = await query
                .ProjectTo<TagBasicViewModel>()
                .ToListAsync();

            return result;
        }

    }
}
