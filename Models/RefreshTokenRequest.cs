﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class RefreshTokenRequest
    {
        public string token { get; set; }
        public string refreshToken { get; set; }

    }
}
