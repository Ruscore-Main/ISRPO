using ISRPO2lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ISRPO2lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private int countEng = 0;
        private int countFrench = 0;
        private int countNem = 0;
        private int countNone = 0;
        private int curPage = 0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /////////

        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult TaskSecond()
        {
            return View();
        }

        public IActionResult TaskThird()
        {
            int[] arr = new int[20];
            string arrDisp = "";
            Random rnd = new Random();
            int count = 0, sum = 0;
            for (int i = 0; i < 20; i++)
            {
                arr[i] = rnd.Next(-15, 40);
                if (arr[i] < 0)
                {
                    count++;
                    sum += arr[i];
                }
                arrDisp += $"{arr[i]}\t";
            }
            ViewBag.ArrayDisp = arrDisp;
            if (count == 0)
            {
                ViewBag.Result = "0";
            }
            else
            {
                ViewBag.Result = $"{Convert.ToDouble(sum)/Convert.ToDouble(count)}";
            }
            return View();
        }

        [HttpPost]
        public IActionResult TaskFirst(string x, string y, string z)
        {
            try
            {
                int a = Convert.ToInt32(x), b = Convert.ToInt32(y), c = Convert.ToInt32(z);
                if (a > 0 && b > 0 && c > 0)
                {
                    if (a + b <= c || a + c <= b || b + c <= a)
                        ViewBag.Result = "Не существует";
                    else
                        ViewBag.Result = "Существует";
                }
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult TaskSecond(string first, string second, string third, string fourth, string fifth)
        {
            
            try
            {
                List<string> values = new List<string>
            {
                first, second, third, fourth, fifth
            };
                foreach (string key in Request.Form.Keys)
                {
                    if (key.StartsWith("Lang"))
                    {
                        string el = Request.Form[key];
                        if (el == "1")
                        {
                            countEng++;
                        }
                        else if (el == "2")
                        {
                            countNem++;
                        }
                        else if (el == "3")
                        {
                            countFrench++;
                        }
                        else if (el == "0")
                        {
                            countNone++;
                        }
                    }

                }
                ViewBag.Result = $"Английский: {countEng}\nНемецкий: {countNem}\nФранцузский: {countFrench}\nНикакой: {countNone}";
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
