using K2.Application.Models;
using K2.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace K2.Application.Services
{
    public class JuroService : IJuroService
    {
        public double GetTaxa()
        {
            return Juros.TaxaJuros;
        }
    }
}
