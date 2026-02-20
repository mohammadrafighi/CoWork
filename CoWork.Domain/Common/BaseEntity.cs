using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Common
{
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; protected set; }
    }
}
