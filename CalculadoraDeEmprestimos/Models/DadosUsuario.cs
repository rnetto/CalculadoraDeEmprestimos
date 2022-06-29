using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDeEmprestimos.Models
{
    public class DadosUsuario
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal LimiteCredTotal6 { get; set; }
        public decimal LimiteCredTotal12 { get; set; }
        public decimal LimiteCredTotal24 { get; set; }
        public decimal LimiteCredTotal36 { get; set; }
    }
}
