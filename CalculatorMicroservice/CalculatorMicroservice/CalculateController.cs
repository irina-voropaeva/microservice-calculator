using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorMicroservice
{
    public class CalculateController : Controller
    {
        private string authUrl = "http://localhost:5000/TokenValidation/GetIsTokenValid";
        
        public IActionResult Calculate(string type, string operation, string number1, string number2, string token)
        {
            if (IsAuthenticated(token))
            {
                return Ok("Hello))");
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }

        private bool IsAuthenticated(string token)
        {
            return true;
        }
    }
}
