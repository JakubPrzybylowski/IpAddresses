﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ip.Addresses.UI.DialogServices
{
    public class DialogService : IDialogService
    {
        public void ShowMessageBox(string text)
        {
            MessageBox.Show(text);
        }
    }
}
