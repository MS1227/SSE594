using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Message
    {
        string authorName;
        string message;

        public Message(string authorName, string message)
        {
            this.authorName = authorName;
            this.message = message;
        }

        public string toString()
        {
            return authorName + ": " + message;
        }
    }
}
