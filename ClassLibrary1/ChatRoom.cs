using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class ChatRoom
    {
        string m_Name;
        private Dictionary<string, User> m_Users;
        private List<Message> m_Messages;

        public ChatRoom(string name)
        {
            this.m_Name = name;
            m_Users = new Dictionary<string, User>();
            m_Messages = new List<Message>();
        }

        public string getName()
        {
            return m_Name;
        }

        public bool addUser(User user)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (!m_Users.ContainsKey(user.getName()))
            {
                m_Users.Add(user.getName(), user);
                user.addToChatRoom(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool hasUser(string name)
        {
            return m_Users.ContainsKey(name);
        }

        public User getUser(string name)
        {
            return m_Users[name];
        }

        internal void removeUser(User user)
        {
            m_Users.Remove(user.getName());
        }

        public int getNumUsers()
        {
            return m_Users.Count;
        }

        public void addMessage(User user, string message)
        {
            m_Messages.Add(new Message(user.getName(), message));
        }

        public List<Message> getMessageList()
        {
            return m_Messages;
        }
    }
}
