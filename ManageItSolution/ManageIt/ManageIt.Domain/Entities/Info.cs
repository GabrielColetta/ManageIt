using System;

namespace ManageIt.Domain.Entities
{
    public class Info
    {
        public long Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public string Version { get; set; }
        public string Email { get; set; }
    }
}
