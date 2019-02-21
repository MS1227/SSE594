using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class ChatRoom
    {
        string name;
        private Dictionary<string, User> users;
        private List<Message> messages;

        public ChatRoom(string name)
        {
            this.name = name;
            users = new Dictionary<string, User>();
            messages = new List<Message>();
        }

        public string getName()
        {
            return name;
        }

        public bool addUser(User user)
        {
            //myUsers.Add(new User((short)myUsers.Count, name));
            if (!users.ContainsKey(user.getName()))
            {
                users.Add(user.getName(), user);
                user.addToChatRoom(this);
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

        public void addMessage(User user, string message)
        {
            messages.Add(new Message(user.getName(), message));
        }

        public List<Message> getMessageList()
        {
            return messages;
        }
    }
}
