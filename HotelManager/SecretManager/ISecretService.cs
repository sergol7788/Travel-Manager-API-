﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.API.SecretManager
{
    public interface ISecretService
    {
        string SecretKey { get; }
        string ApplicationId { get; }

        string SecretEndPoint { get; }
    }
}