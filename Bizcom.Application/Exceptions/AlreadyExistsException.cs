using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        private const string _message = "Already exists";
        public AlreadyExistsException(string name) 
            :base($"{name} {_message}") { }
        public AlreadyExistsException() 
            :base(_message) { }
    }
}
