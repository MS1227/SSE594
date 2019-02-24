using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class User
    {
        private string m_Name;
        private ChatRoom m_Chat;

        public User(string name)
        {
            m_Name = name;
        }

        public void addToChatRoom(ChatRoom myChat)
        {
            m_Chat = myChat;
        }

        public string getName()
        {
            return m_Name;
        }

        public void addMessageToChat(string message)
        {
            m_Chat.addMessage(this, message);
        }
    }
}
