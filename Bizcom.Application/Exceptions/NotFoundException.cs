using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        private const string _message = "Not Found";
        public NotFoundException(string name) 
            :base($"{name} {_message}") { }
        public NotFoundException() 
            :base(_message) { }
    }
}
