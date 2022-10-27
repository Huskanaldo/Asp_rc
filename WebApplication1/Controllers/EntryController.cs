using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult InputRuter(int id)
        {
            return Content(id.ToString());
        }

        public IActionResult InputQuery(int a, int b)
        {
            return Content(a.ToString() + "" + b.ToString());
        }


        [HttpGet]

        public IActionResult InputForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InputForm(int a, int b)
        {
            return Content((a + b).ToString());
        }


        public IActionResult CalculadoraGrafica(int a, int b, string op)
        {
            int res = 0;
            switch (op)
            {
                case "+":
                    res = a + b;
                    break;

                case "-":
                    res = a - b;
                    break;

                case "*":
                    res = a * b;
                    break;

                case "/":
                    res = a / b;
                    break;
                
            }
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.res = res;

            return View();

        }

        public IActionResult comprimento()
        {
            return View();
        }
        [HttpPost]
        public IActionResult comprimento(string name)
        {
            int hora = DateTime.Now.Hour;
            string dia = "";
            if (hora > 0 && hora < 12)
            {
                dia = "Bom dia, ";
            }
            else if (hora > 12 && hora < 20)
            {
                dia = "Bom tarde, ";
            }
            else if (hora > 20 && hora < 0)
            {
                dia = "Bom noite, ";
            }

            ViewData["dia"] = dia;
            ViewData["name"] = name;

            return View();
        }

        public IActionResult Calc()
        {
            return View();
        }


        public IActionResult Operand(string digit)
        {
            string op = HttpContext.Session.GetString("op") ?? "";

            op += digit;

            HttpContext.Session.SetString("op", op);

            return View("Calc");
        }

        public IActionResult Clear(string digit)
        {
            HttpContext.Session.SetString("op", "");

            return View("Calc");
        }
        public IActionResult Add()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            HttpContext.Session.SetInt32("res", res);

            HttpContext.Session.SetString("op", "");

            HttpContext.Session.SetString("sinal", "+");


            return View("Calc");
        }

        public IActionResult Sub()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            HttpContext.Session.SetInt32("res", res);

            HttpContext.Session.SetString("op", "");

            HttpContext.Session.SetString("sinal", "-");

            return View("Calc");
        }

        public IActionResult Multiply()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            HttpContext.Session.SetInt32("res", res);

            HttpContext.Session.SetString("op", "");

            HttpContext.Session.SetString("sinal", "*");

            return View("Calc");
        }

        public IActionResult Division()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            HttpContext.Session.SetInt32("res", res);

            HttpContext.Session.SetString("op", "");

            HttpContext.Session.SetString("sinal", "/");

            return View("Calc");
        }

        public IActionResult Result()
        {
            int op = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            int res = Convert.ToInt32(HttpContext.Session.GetInt32("res") ?? 0);

            String sinal = HttpContext.Session.GetString("sinal") ?? "";

            HttpContext.Session.SetString("op", res.ToString());

            int resultado = 0;

            switch (sinal)
            {
                case "+":
                    resultado = res + op;
                    break;
                case "-":
                    resultado = res - op;
                    break;
                case "*":
                    resultado = res * op;
                    break;
                case "/":
                    resultado = res / op;
                    break;
                case "^": 
                    resultado = res^ op;
                    break;

            }

            HttpContext.Session.SetString("op", resultado.ToString());
            return View("Calc");
        }

       public IActionResult qua()
       {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            int op = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

            HttpContext.Session.SetInt32("res", res);
            HttpContext.Session.SetString("sinal", "√");

            res = Convert.ToInt32(Math.Sqrt(op));


            HttpContext.Session.SetString("op", res.ToString());

            return View("Calc");
       }


        public IActionResult fra()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            int op = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

            HttpContext.Session.SetInt32("res", res);
            HttpContext.Session.SetString("op", "");

            int c = op;

            for(int u = c-1; u > 0; u--)
            {
                c *= u;
                op--;
            }

            res = Convert.ToInt32(c);


            HttpContext.Session.SetString("op", res.ToString());
            return View("Calc");
        }


        public IActionResult sob()
        {
             
                int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

                HttpContext.Session.SetInt32("res", res);

                HttpContext.Session.SetString("op", "");
                HttpContext.Session.SetString("operador", "^");

                return View("Calc");
        }

        public IActionResult Mm()
        {
            int res = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");
            int op = Convert.ToInt32(HttpContext.Session.GetString("op") ?? "");

            HttpContext.Session.SetInt32("res", res);
            HttpContext.Session.SetString("op", "");

            res = Convert.ToInt32(-op);

            HttpContext.Session.SetString("op", res.ToString());
            return View("Calc");
        }

       






    }

}
