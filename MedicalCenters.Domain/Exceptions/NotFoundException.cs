using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string notFound_ObjectType,string id)
        {
            NotFound_ObjectType = notFound_ObjectType;
            Id = id;
        }
        public string NotFound_ObjectType { get;private set; }
        public string Id { get; private set; }

    }
}
