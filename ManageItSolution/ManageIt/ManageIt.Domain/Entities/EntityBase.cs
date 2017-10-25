using ManageIt.Domain.Contracts.Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageIt.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        public long Id { get; set; }
        public DateTime IncludedDate { get; set; }
        public bool IsDeleted { get; set; }

        public abstract bool Validate(IEnumerable<string> erros);
    }
}
