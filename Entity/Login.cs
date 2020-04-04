using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Login
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
