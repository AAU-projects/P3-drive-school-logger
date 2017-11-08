using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class User
    {
        public User(int id, string firstname, string lastname, string phone, string email, string cpr, 
            string address, string zip, string city, string username, string password, string picturePath, bool sysmin)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Email = email;
            Cpr = cpr;
            Address = address;
            Zip = zip;
            City = city;
            Username = username;
            Password = password;
            PicturePath = picturePath;
            Sysmin = sysmin;
        }

        public User(DataTable userTable)
        {
            Id = (int)userTable.Rows[0][0];
            Firstname = (string)userTable.Rows[0][1];
            Lastname = (string)userTable.Rows[0][2];
            Phone = (string)userTable.Rows[0][3];
            Email = (string)userTable.Rows[0][4];
            Cpr = (string)userTable.Rows[0][5];
            Address = (string)userTable.Rows[0][6];
            Zip = (string)userTable.Rows[0][7];
            City = (string)userTable.Rows[0][8];
            Username = (string)userTable.Rows[0][9];
            Password = (string)userTable.Rows[0][10];
            PicturePath = (string)userTable.Rows[0][11];
            Sysmin = Convert.ToBoolean((string) userTable.Rows[0][12]);
        }

        public int Id { get;}
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
        public string Password { get; }
        public string PicturePath { get; }
        public bool Sysmin { get; }

        public override string ToString()
        {
            return Fullname;
        }
    }
}
