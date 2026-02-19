using CoWork.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Entities
{
    public class Message:BaseEntity<Guid>
    {
        public string Title {  get; set; }
        public string Description {  get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

    }
}
