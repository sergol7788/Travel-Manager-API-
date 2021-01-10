
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Hotel.API.SecretManager
{
    public class SecretService : ISecretService
    {
        public string SecretKey { get; private set; }

        public string ApplicationId { get; private set; }

        public string SecretEndPoint { get; private set; }
        


        public SecretService(string applicationId, string secretKey, string secretEndPoint)
        {
            SecretKey = secretKey;
            ApplicationId = applicationId;
            SecretEndPoint = secretEndPoint;
        }
    }
}
