using System;
using System.Collections.Generic;

namespace Server
{
    public class Server
    {
        private Dictionary<string, ChatRoom> myChatRooms;

        public Server()
        {
            myChatRooms = new Dictionary<string, ChatRoom>();
        }

        public bool createChatRoom(string name)
        {
            if (!myChatRooms.ContainsKey(name))
            {
                myChatRooms.Add(name, new ChatRoom(name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public ChatRoom getChatRoom(string name)
        {
            return myChatRooms[name];
        }
    }
}
