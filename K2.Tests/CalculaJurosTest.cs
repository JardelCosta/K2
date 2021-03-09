using K2.Application.Services.Interfaces;
using K2.CalculaJuros.Application.Services;
using K2.CalculaJuros.Controllers;
using K2.Juros.Controllers;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace K2.Tests
{
    public class CalculaJurosTest
    {
        [Fact(DisplayName = "Aplicar cálculo com taxa de juros")]
        public void CalcularJuros_DeveRetornarOValorCalculado()
        {
            //Arrange
            var _clientFactory = new Mock<IHttpClientFactory>().Object;
            var _service = new CalculaJurosService(_clientFactory);


            //Act
            var resultado = _service.AplicarCalculo(100, 5, 0.01);
            var resultado2 = _service.AplicarCalculo(111.5, 5, 0.01);
            var resultado3 = _service.AplicarCalculo(50, 10, 0.01);
            var resultado4 = _service.AplicarCalculo(5000, 24, 0.01);


            //Assert
            Assert.Equal("105,10", resultado);
            Assert.Equal("117,18", resultado2);
            Assert.Equal("55,23", resultado3);
            Assert.Equal("6348,67", resultado4);
        }

    }
}
