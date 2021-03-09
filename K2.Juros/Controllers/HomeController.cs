using K2.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2.Juros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IAppService _appService;

        public HomeController(IAppService appService)
        {
            _appService = appService;
        }

        // GET: HomeController
        [HttpGet("/taxajuros")]
        public IActionResult Get()
        {
            return Ok(_appService.GetTaxa());
        }
    }
}
