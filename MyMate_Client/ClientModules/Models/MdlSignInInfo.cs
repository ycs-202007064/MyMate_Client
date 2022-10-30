﻿using ClientModules.Services;
using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_to_Server;

namespace ClientModules.Classes
{
    public class MdlSignInInfo
    {
        public string ID { get; set; }
        public string PW { get; set; }

        public MdlSignInInfo()
        {
            this.ID = "";
            this.PW = "";
        }
        public MdlSignInInfo(string ID, string PW)
        {
            this.ID = ID;
            this.PW = PW;
        }
    }
}