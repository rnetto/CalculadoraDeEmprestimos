using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDeEmprestimos.Models
{
    public class BaseCalcViewModel
    {
        public decimal? ValorMinimo { get; set; }
        public decimal? LimiteCredTotal6 { get; set; }
        public decimal? ValorParcelaCred6 { get; set; }
        public decimal? LimiteCredTotal12 { get; set; }
        public decimal? ValorParcelaCred12 { get; set; }
        public decimal? LimiteCredTotal24 { get; set; }
        public decimal? ValorParcelaCred24 { get; set; }
        public decimal? LimiteCredTotal36 { get; set; }
        public decimal? ValorParcelaCred36 { get; set; }
    }
}
