﻿using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public partial class AdminBusiness : IAdminBusiness
    {
        public List<Location> GetLocations()
        {
            return adminRepository.GetLocations();
        }
        
    }
}
