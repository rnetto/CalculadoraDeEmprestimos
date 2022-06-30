using CalculadoraDeEmprestimos.Data;
using CalculadoraDeEmprestimos.Models;
using System.Linq;

namespace CalculadoraDeEmprestimos.Service
{
    public class CalcEmprestimoService
    {
        private readonly ApplicationDbContext _context;

        public CalcEmprestimoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BaseCalcViewModel GetSaldos(string usuarioId)
        {
            var BaseCalcViewModel = (from bcvm in _context.DadosUsuario
                                     where bcvm.UserId == usuarioId
                                     select new BaseCalcViewModel()
                                     {
                                         ValorMinimo = bcvm.ValorMinimo,
                                         LimiteCredTotal6 = bcvm.LimiteCredTotal6,
                                         LimiteCredTotal12 = bcvm.LimiteCredTotal12,
                                         LimiteCredTotal24 = bcvm.LimiteCredTotal24,
                                         LimiteCredTotal36 = bcvm.LimiteCredTotal36,
                                     }).ToList().FirstOrDefault();

            BaseCalcViewModel.ValorParcelaCred6 = CalcParcela(6, BaseCalcViewModel.LimiteCredTotal6);
            BaseCalcViewModel.ValorParcelaCred12 = CalcParcela(12, BaseCalcViewModel.LimiteCredTotal12);
            BaseCalcViewModel.ValorParcelaCred24 = CalcParcela(24, BaseCalcViewModel.LimiteCredTotal24);
            BaseCalcViewModel.ValorParcelaCred36 = CalcParcela(36, BaseCalcViewModel.LimiteCredTotal36);

            return BaseCalcViewModel;
        }

        public SimulacaoUsuario GetSimulacaoCalc(int qtdMes, decimal ValorPretendido, decimal taxaMensal)
        {
            var simulacaoCalc = new SimulacaoUsuario();

            simulacaoCalc.ValorSimulado = CalcJuros(qtdMes, ValorPretendido, taxaMensal);
            simulacaoCalc.ValorParcelas = CalcParcela(qtdMes, simulacaoCalc.ValorSimulado);
            simulacaoCalc.QtdParcelas = qtdMes;
            simulacaoCalc.CustoEfetivoMensal = taxaMensal;

            return simulacaoCalc;
        }
        public decimal CalcJuros(int mes, decimal valorPretendido, decimal taxaMensal)
        {
            return (mes * (taxaMensal / 100)) * valorPretendido + valorPretendido;
        }

        public decimal CalcParcela(int mes, decimal ValorSimuladoTotal)
        {
            return (ValorSimuladoTotal / mes);
        }
        public void PostSimulacaoCalc(SimulacaoUsuario simulaUser)
        {
            var simulacaoUsuario = _context.SimulacaoUsuario.Where(x => x.UserId == simulaUser.UserId).FirstOrDefault();
            if (simulacaoUsuario != null)
            {
                simulacaoUsuario.ValorPretendido = simulaUser.ValorPretendido;
                simulacaoUsuario.ValorSimulado = simulaUser.ValorSimulado;
                simulacaoUsuario.QtdParcelas = simulaUser.QtdParcelas;
                simulacaoUsuario.ValorParcelas = simulaUser.ValorParcelas;
                simulacaoUsuario.CustoEfetivoMensal = simulaUser.CustoEfetivoMensal;                
            }
            else
            {
                _context.Add(simulaUser);
            }
            
            _context.SaveChanges();
        }
    }
}
