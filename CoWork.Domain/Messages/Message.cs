using CoWork.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Domain.Messages
{
    public class Message:AggregateRoot<Guid>
    {
        public string Title {  get;private set; }
        public string Description {  get;private set; }
        public DateTime SendAt {  get;private set; }
        public Guid SenderId { get;private set; }
        public Guid ReceiverId { get;private set; }
        public MessageType Type { get;private set; }
        private Message() { }
        public Message(string title,string description,Guid senderId,Guid receiverId,MessageType type)
        {
            Title=title;
            Description=description;
            SenderId=senderId;
            ReceiverId=receiverId;
            Type=type;
            SendAt = DateTime.UtcNow;
        }

    }
}
