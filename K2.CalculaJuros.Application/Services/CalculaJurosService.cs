using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace K2.CalculaJuros.Application.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string apiUrl = "https://localhost:44344/taxajuros/";

        public CalculaJurosService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> ObterTaxaDeJuro()
        {
            return await CreateRequest(apiUrl, HttpMethod.Get);
        }

        public string AplicarCalculo(double valorInicial, int meses, double taxaDeJuros)
        {
            var calculo = (valorInicial * (Math.Pow(1 + taxaDeJuros, meses)));
            
            return FormatarValor(calculo);
        }

        public string FormatarValor(double valor)
        {
            var resultado = valor.ToString();
            if (resultado.IndexOf(',') > 0)
                return resultado.Substring(0, resultado.IndexOf(',') + 3);
            return valor.ToString("0.00");
        }

        public double ConverterTaxa(string taxa)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";

            return Convert.ToDouble(taxa, provider);
        }

        public async Task<HttpResponseMessage> CreateRequest(string endpoint, HttpMethod method)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, new Uri(endpoint));
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            return await client.SendAsync(request);
        }
    }
}
