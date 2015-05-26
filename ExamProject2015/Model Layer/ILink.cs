﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    public interface ILink
    {
        string name { get; set; }

        string url { get; set; }

        IFolder locationFolderLink { get; set; }

        string getData();
    }
}
