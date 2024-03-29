﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Client
    {
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string idNumber { get; set; }
        public string uniqueIdNumber { get; set; }
        public string passportNumber { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}