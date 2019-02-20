using System;
using System.Collections.Generic;
using System.Text;

namespace ChatRooms
{
    public class ChatRoom
    {
        string name;
        List<String> messages;

        public ChatRoom(string name)
        {
            this.name = name;
            messages = new List<string>();
        }

        public string getName()
        {
            return name;
        }
    }
}
