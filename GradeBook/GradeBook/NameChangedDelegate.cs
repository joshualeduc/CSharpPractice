﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args); //while not required, general practice seperates a delegate and its arguments between files
}