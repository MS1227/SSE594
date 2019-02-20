using System;
using System.Collections.Generic;
using ChatRooms;
using UserType;

namespace ServerType
{
    public class Server
    {
        private Dictionary<string, ChatRoom> myChatRooms;
        private Dictionary<string, User> myUsers;

        public Server()
        {
            myChatRooms = new Dictionary<string, ChatRoom>();
            myUsers = new Dictionary<string, User>();
        }

        public void createUser(string name)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));

            myUsers.Add(name, new User((short)myUsers.Count, name));
        }

        public User getUser(string name)
        {
            return myUsers[name];
        }

        public int getNumUsers()
        {
            return myUsers.Count;
        }

        public void createChatRoom(string name)
        {
            myChatRooms.Add(name, new ChatRoom(name));
        }

        public ChatRoom getChatRoom(string name)
        {
            return myChatRooms[name];
        }
    }
}
