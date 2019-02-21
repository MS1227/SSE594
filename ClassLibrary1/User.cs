using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class User
    {
        private string name;
        private ChatRoom myChat;

        public User(string name)
        {
            this.name = name;
        }

        public void addToChatRoom(ChatRoom myChat)
        {
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
