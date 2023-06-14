using Bizcom.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Infrastucture.Services
{
    public class JWTConfiguration
    {
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
    }
}
