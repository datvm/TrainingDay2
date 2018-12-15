using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay2.Api.Models.Entities;

namespace TrainingDay2.Api.Models.ViewModels
{

    public class ContactBasicViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
    }

    public class ContactDetailsViewModel : ContactBasicViewModel
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
    }

    public class ContactSearchResultItemEntity
    {

        public Contact Contact { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

    }

    public class ContactSearchResultItemViewModel
    {

        public ContactBasicViewModel Contact { get; set; }
        public IEnumerable<TagBasicViewModel> Tags { get; set; }

    }
    
}
