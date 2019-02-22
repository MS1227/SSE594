using System;
using System.Collections.Generic;

namespace Server
{
    public class Server
    {
        private Dictionary<string, ChatRoom> m_ChatRooms;
        private Dictionary<string, User> m_Users;

        public Server()
        {
            m_ChatRooms = new Dictionary<string, ChatRoom>();
            m_Users = new Dictionary<string, User>();
        }

        public bool addUser(string name)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (!m_Users.ContainsKey(name))
            {
                m_Users.Add(name, new User(name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeUser(User user)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (m_Users.ContainsKey(user.getName()))
            {
                foreach (ChatRoom chat in m_ChatRooms.Values)
                {
                    if(chat.hasUser(user.getName()))
                    {
                        chat.removeUser(user);
                    }
                }
                m_Users.Remove(user.getName());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool connectUserToRoom(User user, ChatRoom chat)
        {
            if (!chat.hasUser(user.getName()))
            {
                user.addToChatRoom(chat);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User getUser(string name)
        {
            return m_Users[name];
        }

        public int getNumUsers()
        {
            return m_Users.Count;
        }

        public int getNumChats()
        {
            return m_ChatRooms.Count;
        }

        public bool createChatRoom(string name)
        {
            if (!m_ChatRooms.ContainsKey(name))
            {
                m_ChatRooms.Add(name, new ChatRoom(name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeChatRoom(ChatRoom chat)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (m_ChatRooms.ContainsKey(chat.getName()))
            {
                m_ChatRooms.Remove(chat.getName());
                return true;
            }
            else
            {
                return false;
            }
        }

        public ChatRoom getChatRoom(string name)
        {
            return m_ChatRooms[name];
        }
        public List<string> listCurrUsers()
        {
            List<string> ret = new List<string>();
            foreach (KeyValuePair<string, User> x in m_Users)
            {
                ret.Add(x.Key);
            }
            return ret;
        }
        public List<ChatRoom> listCurrRooms()
        {
            List<ChatRoom> ret = new List<ChatRoom>();
            foreach (KeyValuePair<string, ChatRoom> x in m_ChatRooms)
            {
                ret.Add(x.Value);
            }
            return ret;
        }
    }
}
