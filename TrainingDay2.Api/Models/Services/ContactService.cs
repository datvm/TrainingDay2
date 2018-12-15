using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay2.Api.Models.Entities;
using TrainingDay2.Api.Models.ViewModels;

namespace TrainingDay2.Api.Models.Services
{

    public interface IContactService
    {
        Task<IEnumerable<ContactSearchResultItemViewModel>> SearchAsync(string keyword);
    }

    public class ContactService : BaseDbContextService, IContactService
    {
        public ContactService(TrainingContext trainingContext) : base(trainingContext)
        {
        }

        public async Task<IEnumerable<ContactSearchResultItemViewModel>> SearchAsync(string keyword)
        {
            var query = this.DbContext.Contact
                .AsNoTracking()
                .Include(q => q.ContactTag)
                .Where(q => q.FirstName.Contains(keyword) ||
                    q.LastName.Contains(keyword) ||
                    q.Company.Contains(keyword));

            return await this.ToContactSearchResultAsync(query);
        }

        public async Task<IEnumerable<ContactSearchResultItemViewModel>> SearchByTagAsync(string tag)
        {
            int tagId = 1;

            var query = this.DbContext.ContactTag
                .AsNoTracking()
                .Where(q => q.TagId == tagId)
                .Select(q => q.Contact)
                .Include(q => q.ContactTag);

            return await this.ToContactSearchResultAsync(query);
        }

        private async Task<IEnumerable<ContactSearchResultItemViewModel>> ToContactSearchResultAsync(IQueryable<Contact> source)
        {
            var result = await source
                .Select(q => new ContactSearchResultItemEntity()
                {
                    Contact = q,
                    Tags = q.ContactTag
                        .Select(p => p.Tag),
                })
                .ProjectTo<ContactSearchResultItemViewModel>()
                .ToListAsync();

            return result;
        }

    }

}
