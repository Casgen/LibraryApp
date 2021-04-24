using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Schema
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error) => error.WithLocations(error.Locations).WithMessage(error.Exception.Message);
    }
}
