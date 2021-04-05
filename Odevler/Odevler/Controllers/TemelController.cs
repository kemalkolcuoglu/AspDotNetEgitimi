using Microsoft.AspNetCore.Mvc;
using Odevler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Controllers
{
    public class TemelController : Controller
    {
        protected OdevContext _context;
        public TemelController(OdevContext context)
        {
            _context = context;
        }
    }
}
