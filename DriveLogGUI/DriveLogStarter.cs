﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogGUI.Windows;

namespace DriveLogGUI
{
    class DriveLogStarter
    {
        public void Start()
        {
            LoginForm login = new LoginForm();
            Application.Run(login);
        }
    }
}
