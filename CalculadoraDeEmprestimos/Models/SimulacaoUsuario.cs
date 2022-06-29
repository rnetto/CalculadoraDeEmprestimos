using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDeEmprestimos.Models
{
    public class SimulacaoUsuario
    {
        public int Id { get; set; }
        public string UserId { get; set; }        
        public decimal ValorPretendido { get; set; }
        public decimal ValorSimulado { get; set; }
        public int QtdParcelas { get; set; }
        public decimal ValorParcelas { get; set; }
        public decimal CustoEfetivoMensal { get; set; }
    }
}
