﻿using System;
using System.Collections.Generic;
using System.Data;
using DriveLogCode.DataAccess;

namespace DriveLogCode.Objects
{
    public class User
    {
        public User()
        {
            
        }
        public User(int id, string firstname, string lastname, string phone, string email, string cpr, 
            string address, string zip, string city, string username, string password, string picturePath, string signaturePath, bool sysmin)
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
            SignaturePath = signaturePath;
            Sysmin = sysmin;

            CalculateProgress();
        }

        public User(DataTable userTable, int index = 0)
        {
            Id = (int)userTable.Rows[index][0];
            Firstname = (string)userTable.Rows[index][1];
            Lastname = (string)userTable.Rows[index][2];
            Phone = (string)userTable.Rows[index][3];
            Email = (string)userTable.Rows[index][4];
            Cpr = (string)userTable.Rows[index][5];
            Address = (string)userTable.Rows[index][6];
            Zip = (string)userTable.Rows[index][7];
            City = (string)userTable.Rows[index][8];
            Username = (string)userTable.Rows[index][9];
            Password = (string)userTable.Rows[index][10];
            PicturePath = (string)userTable.Rows[index][11];
            SignaturePath = (string)userTable.Rows[index][12];
            Sysmin = Convert.ToBoolean((string) userTable.Rows[index][13]);

            CalculateProgress();
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
        public string SignaturePath { get; }
        public bool Sysmin { get; }
        public int TheoreticalProgress { get; private set; }
        public int PracticalProgress { get; private set; }

        private void CalculateProgress()
        {
            List<Lesson> lessonsList = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(Id);
            List<LessonTemplate> lessonTemplates = DatabaseParser.GetTemplatesList();
            TheoreticalProgress = 0;
            PracticalProgress = 0;

            foreach (Lesson l in lessonsList)
            {
                LessonTemplate template = lessonTemplates.Find(x => l.TemplateID == x.Id);

                if (template == null) continue;

                if (l.Completed && l.Progress == template.Time && template.Type == "Theoretical")
                    TheoreticalProgress++;
                else if (l.Completed && l.Progress == template.Time && template.Type == "Practical")
                    PracticalProgress++;
            }
        }

        public override string ToString()
        {
            return Fullname;
        }
    }
}