using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class User
    {
        public User(string firstname, string lastname, string phone, string email, string cpr, 
            string address, string zip, string city, string username, string picturePath, bool sysmin)
        {
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Cpr = cpr;
            Address = address;
            Zip = zip;
            City = city;
            Username = username;
            PicturePath = picturePath;
            Sysmin = sysmin;
        }

        public string Fullname => $"{Firstname} {Lastname}";

        public string FullAddress => $"{Address}, {Zip} {City}";

        public string Firstname { get; }

        public string Lastname { get; }

        public string Phone { get; }

        public string Email { get; }

        public string Cpr { get; }

        public string Address { get; }

        public string Zip { get; }

        public string City { get; }

        public string Username { get; }

        public string PicturePath { get; }

        public bool Sysmin { get; }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
