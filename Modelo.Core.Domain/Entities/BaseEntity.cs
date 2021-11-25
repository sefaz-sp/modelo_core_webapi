using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
    }
}
