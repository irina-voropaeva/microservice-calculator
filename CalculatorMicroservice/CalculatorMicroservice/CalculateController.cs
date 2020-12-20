using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorMicroservice
{
    public class CalculateController : BaseController
    {
        private readonly CalculatorService _calculatorService;
        public CalculateController()
        {
            _calculatorService = new CalculatorService();
        }
        
        [HttpPost("/calculate")]
        public IActionResult Calculate([Required] NumberType type, 
            [Required] OperationType operation, 
            [Required] double real1,
            double imaginary1,
            [Required] double real2,
            double imaginary2)
        {
            if (RequestIsAuthenticated(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")))
            {
                return Ok(_calculatorService.Calculate(type, operation, real1, real2, imaginary1, imaginary2));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }
    }
}
