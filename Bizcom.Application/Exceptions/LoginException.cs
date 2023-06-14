using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Exceptions
{
    public class LoginException : Exception
    {
        private const string _message = "Login or password incorrect";
        public LoginException() 
            :base(_message){ }
    }
}
