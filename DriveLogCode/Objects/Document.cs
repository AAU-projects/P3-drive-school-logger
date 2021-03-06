﻿using System;
using System.Data;
using DriveLogCode.Exceptions;

namespace DriveLogCode.Objects
{
    public class Document
    {
        public Document(int id, string title, string type, DateTime uploadDate, User uploader, string url)
        {
            Id = id;
            Title = title;
            Type = type;
            UploadDate = uploadDate;
            Uploader = uploader;
            Url = url;
            Uri = new Uri(Url); 
        }

        public Document(DataTable table)
        {
            if (table == null)
                throw new EmptyDataTableException("Datatabel is empty");


            Id = (int) table.Rows[0][0];
            Title = (string) table.Rows[0][1];
            Type = (string) table.Rows[0][2];
            UploadDate = (DateTime) table.Rows[0][3];
            Uploader = new User(DataAccess.MySql.GetUserByID((int) table.Rows[0][4]));
            Url = (string) table.Rows[0][5];
            Uri = new Uri(Url);
        }

        public int Id { get;}
        public string Title { get;}
        public string Type { get;}
        public DateTime UploadDate { get;}
        public User Uploader { get;}
        public string Url { get;}
        public Uri Uri { get;}

    }
}
