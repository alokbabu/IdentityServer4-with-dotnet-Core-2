using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Idsrv4.Controllers
{
    public class ProtectedController : Controller
    {
        // GET: /<controller>/
		[Route("api/protected")]
        [Authorize]
        public IActionResult Index()
        {
			ViewBag.Content = "This is a protected content";
            return View();
        }
    }
}
