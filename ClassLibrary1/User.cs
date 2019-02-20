using System;
using System.Collections.Generic;
using System.Text;

namespace UserType
{
    public class User
    {
        private short id;
        private string name;

        public User(short id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public short getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }
    }
}
