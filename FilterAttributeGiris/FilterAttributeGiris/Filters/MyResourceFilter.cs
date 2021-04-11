using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterAttributeGiris.Filters
{
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
