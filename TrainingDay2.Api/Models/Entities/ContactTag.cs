using System;
using System.Collections.Generic;

namespace TrainingDay2.Api.Models.Entities
{
    public partial class ContactTag
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int TagId { get; set; }

        public Contact Contact { get; set; }
        public Tag Tag { get; set; }
    }
}
