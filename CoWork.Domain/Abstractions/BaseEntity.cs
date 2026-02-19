using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Abstraction
{
    public abstract class BaseEntity<Tkey>
        where Tkey : struct
    {
        public Tkey Id { get;protected set; }
    }
}
