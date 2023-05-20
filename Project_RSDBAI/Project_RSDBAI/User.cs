using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_RSDBAI
{
    internal class User
    {
        private string id, ten, sdt, email;

        public User() { }
        public User(string id, string ten, string sdt, string email)
        {
            this.id = id;
            this.ten = ten;
            this.sdt = sdt;
            this.email = email;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
    }
}
