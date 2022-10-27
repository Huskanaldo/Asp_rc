using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    public class ajaxController : Controller
    {
        public IActionResult ajax()
        {
            return View();
        }
        public IActionResult OperandAjax(string digit)
        {
            string op = HttpContext.Session.GetString("op") ?? "";

            op += digit;

            HttpContext.Session.SetString("op", op);

            return Ok(op);
        }

        public IActionResult ClearOperandAjax()
        {
            HttpContext.Session.SetString("op", "");

            return Ok("");
        }

        public IActionResult OperationAjax()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

            HttpContext.Session.SetString("op", "");

            HttpContext.Session.SetInt32("res", res);

            return Ok("");
        }

        public IActionResult ResultAjax()
        {
            int op = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

            int res = (HttpContext.Session.GetInt32("res") ?? 0) + op;

            HttpContext.Session.SetString("op", res.ToString());

            return Ok(res);
        }
    }
}
