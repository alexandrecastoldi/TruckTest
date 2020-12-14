using System;
using System.Collections.Generic;
using System.Text;

namespace TruckTest.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public virtual bool IsTransient()
        {
            return Id == null || Id.Equals(default(TId));
        }

        public bool Active { get; set; }
        public DateTime? LastUpdate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}