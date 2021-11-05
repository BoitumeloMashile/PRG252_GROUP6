using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG252__Project_Group_6
{
    class reg_Login
    {
        private string userName;
        private string email;
        private string password;

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public reg_Login(string userName, string email, string password)
        {
            this.userName = userName;
            this.email = email;
            this.password = password;
        }

        public reg_Login()
        {
        }

        public reg_Login(string text1, string text2)
        {
        }

        public List<reg_Login> Users()
        {
            List<reg_Login> myList = new List<reg_Login>();
            myList.Add(new reg_Login(email, userName, password));
            return myList;
        }
    }
}
