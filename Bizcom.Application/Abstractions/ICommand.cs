using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcom.Application.Abstractions
{
    public interface ICommand<out TRes> : IRequest<TRes>
    {
    }
}
