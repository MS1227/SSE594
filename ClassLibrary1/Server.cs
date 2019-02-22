using System;
using System.Collections.Generic;

namespace Server
{
    public class Server
    {
        private Dictionary<string, ChatRoom> myChatRooms;
        private Dictionary<string, User> users;

        public Server()
        {
            myChatRooms = new Dictionary<string, ChatRoom>();
        }

        public bool addUser(User user)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (!users.ContainsKey(user.getName()))
            {
                users.Add(user.getName(), user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User getUser(string name)
        {
            return users[name];
        }

        public int getNumUsers()
        {
            return users.Count;
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
