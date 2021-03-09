using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace K2.CalculaJuros.Application.Services
{
    public interface ICalculaJurosService
    {
        Task<HttpResponseMessage> ObterTaxaDeJuro();

        string AplicarCalculo(double valorInicial, int meses, double taxaDeJuros);
        double ConverterTaxa(string taxa);
    }
}
