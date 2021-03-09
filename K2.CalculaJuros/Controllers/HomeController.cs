using K2.CalculaJuros.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace K2.CalculaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICalculaJurosService _service;

        public HomeController(ICalculaJurosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/calculajuros/valorInicial/{valorInicial}/meses/{meses}")]
        public async Task<IActionResult> Get(double valorInicial, int meses)
        {
            var response = await _service.ObterTaxaDeJuro();
            if (response == null)
                return BadRequest("Não foi possível obter a taxa de juros");
            
            var responseBody = await response.Content.ReadAsStringAsync();

            if ((int)response.StatusCode >= 200 &&
                (int)response.StatusCode <= 299)
            {
                var taxaDeJuros = _service.ConverterTaxa(responseBody);
                if (taxaDeJuros == 0)
                    return BadRequest("Não foi possível converter a taxa de juros");

                return Ok(_service.AplicarCalculo(valorInicial, meses, taxaDeJuros));
            }

            return BadRequest(responseBody);
        }

        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult Code()
        {           
            return Ok("https://github.com/JardelCosta/K2");
        }

    }
}
