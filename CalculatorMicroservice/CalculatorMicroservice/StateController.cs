using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorMicroservice
{
    public class StateController : BaseController
    {
        private readonly StateService _stateService;
        public StateController()
        {
            _stateService = new StateService();
        }

        [HttpGet("/state")]
        public IActionResult GetState([Required] NumberType type,
            [Required] OperationType operation,
            [Required] string token)
        {
            if (RequestIsAuthenticated(token))
            {
                return Ok(_stateService.GetState(token));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }

        [HttpPost("/state")]
        public IActionResult AddState([Required] NumberType type,
            [Required] OperationType operation,
            [Required] string token)
        {
            if (RequestIsAuthenticated(token))
            {
                return Ok(_stateService.SetState(operation, type));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }

        [HttpDelete("/state")]
        public IActionResult RemoveState([Required] string email,
            [Required] string token)
        {
            if (RequestIsAuthenticated(token))
            {
                return Ok(_stateService.DeleteState(email));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }
    }
}
