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
        public IActionResult GetState()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (RequestIsAuthenticated(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")))
            {
                return Ok(_stateService.GetState(RequestUserEmailByToken(token)));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }

        [HttpPost("/state")]
        public IActionResult AddState([Required] NumberType type,
            [Required] OperationType operation)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (RequestIsAuthenticated(token))
            {
                return Ok(_stateService.SetState(RequestUserEmailByToken(token), operation, type));
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }

        [HttpDelete("/state")]
        public IActionResult RemoveState()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (RequestIsAuthenticated(Request.Headers["Authorization"].ToString().Replace("Bearer ", "")))
            {
                _stateService.DeleteState(RequestUserEmailByToken(token));
                return Ok();
            }
            else
            {
                return Unauthorized("Please authorize!");
            }
        }
    }
}
