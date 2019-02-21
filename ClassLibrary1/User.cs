using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class User
    {
        private string name;
        private ChatRoom myChat;

        public User(string name, ChatRoom myChat)
        {
            this.name = name;
            this.myChat = myChat;
        }

        public string getName()
        {
            return name;
        }

        public void addMessageToChat(string message)
        {
            myChat.addMessage(this, message);
        }
    }
}
