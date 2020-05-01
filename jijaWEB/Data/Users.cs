using Microsoft.EntityFrameworkCore;
using System;

namespace jijaWEB.Data
{
    public class Users
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _surname;

        public string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        private string _phone;

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _mail;

        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        private int _id_role;

        public int id_role
        {
            get { return _id_role; }
            set { _id_role = value; }
        }





        private string _login;

        public string login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static implicit operator DbSet<object>(Users v)
        {
            throw new NotImplementedException();
        }
    }
}
