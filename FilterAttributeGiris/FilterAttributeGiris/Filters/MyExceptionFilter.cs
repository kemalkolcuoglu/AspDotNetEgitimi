using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterAttributeGiris.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            List<string> degerler = new List<string>();
            degerler.Add(context.HttpContext.Request.Path);
            degerler.Add(context.HttpContext.Request.Host.Value);
            degerler.Add(context.Exception.Message);

        }
    }
}
