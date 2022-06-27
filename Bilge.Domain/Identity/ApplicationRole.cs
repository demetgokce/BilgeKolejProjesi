﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.Identity
{
   public class ApplicationRole:IdentityRole
    {

        public string Description { get; set; }
    }
}