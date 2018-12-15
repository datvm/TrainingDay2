using System;
using System.Collections.Generic;

namespace TrainingDay2.Api.Models.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            ContactTag = new HashSet<ContactTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ContactTag> ContactTag { get; set; }
    }
}
