using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public int Token { get; set; }    
        public DateTime Expiration { get;set; }

    }
}
