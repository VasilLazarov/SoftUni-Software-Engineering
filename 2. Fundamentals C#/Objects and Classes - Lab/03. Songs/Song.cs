﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Songs
{
    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }
    }
}
