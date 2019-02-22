using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Message
    {
        string m_AuthorName;
        string m_Message;

        public Message(string authorName, string message)
        {
            this.m_AuthorName = authorName;
            this.m_Message = message;
        }

        public string toString()
        {
            return m_AuthorName + ": " + m_Message;
        }
    }
}
