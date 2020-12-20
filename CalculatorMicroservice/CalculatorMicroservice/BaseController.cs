using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorMicroservice
{
    public class BaseController : Controller
    {
        private string authUrl = "http://localhost:5000/TokenValidation/GetIsTokenValid";

        protected bool RequestIsAuthenticated(string token)
        {
            var client = new HttpClient { BaseAddress = new Uri(authUrl) };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = client.GetAsync("").Result;
            client.Dispose();
            return response.IsSuccessStatusCode;
        }

        protected string RequestUserEmailByToken(string token)
        {
            return "helo";
        }
    }
}
