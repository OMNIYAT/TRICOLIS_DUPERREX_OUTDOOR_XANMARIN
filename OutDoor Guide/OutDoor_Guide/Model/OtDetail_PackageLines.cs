﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class OtDetail_PackageLines
    {
        public OtDetail_PackageLines() { }

        public int serviceid { get; set; }
        public int packageid { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
