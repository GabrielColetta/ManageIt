﻿using System;
using System.Collections.Generic;

namespace ManageIt.Domain.Contracts.Patterns
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime IncludedDate { get; set; }
        bool IsDeleted { get; set; }
        bool Validate(IEnumerable<string> erros);
    }
}
