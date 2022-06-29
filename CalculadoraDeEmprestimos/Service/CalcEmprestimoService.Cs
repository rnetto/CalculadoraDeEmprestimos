using CalculadoraDeEmprestimos.Data;
using CalculadoraDeEmprestimos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var BaseCalcViewModel = from bcvm in _context.DadosUsuario
                                    where bcvm.UserId == usuarioId
                                    select new BaseCalcViewModel()
                                    {
                                        ValorMinimo = bcvm.ValorMinimo,
                                        LimiteCredTotal6 = bcvm.LimiteCredTotal6,
                                        ValorParcelaCred6 = CalcParcela(6, bcvm.LimiteCredTotal6),
                                        LimiteCredTotal12 = bcvm.LimiteCredTotal12,
                                        ValorParcelaCred12 = CalcParcela(12, bcvm.LimiteCredTotal12),
                                        LimiteCredTotal24 = bcvm.LimiteCredTotal24,
                                        ValorParcelaCred24 = CalcParcela(24, bcvm.LimiteCredTotal24),
                                        LimiteCredTotal36 = bcvm.LimiteCredTotal36,
                                        ValorParcelaCred36 = CalcParcela(36, bcvm.LimiteCredTotal36),
                                    };

            return BaseCalcViewModel.FirstOrDefault();
        }

        public SimulacaoUsuario GetSimulacaoCalc(int qtdMes ,decimal ValorPretendido, decimal taxaMensal)
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
            return (mes * taxaMensal) * valorPretendido;
        }

        public decimal CalcParcela(int mes, decimal ValorSimuladoTotal)
        {
            return (ValorSimuladoTotal / mes);
        }
        public void PostSimulacaoCalc(SimulacaoUsuario simulaUser)
        {
            var simulacaoUsuario = _context.SimulacaoUsuario.Where(x => x.UserId == simulaUser.UserId).FirstOrDefault();

            simulacaoUsuario.ValorPretendido = simulaUser.ValorPretendido;
            simulacaoUsuario.ValorSimulado = simulaUser.ValorSimulado;
            simulacaoUsuario.QtdParcelas = simulaUser.QtdParcelas;
            simulacaoUsuario.ValorParcelas = simulaUser.ValorParcelas;
            simulacaoUsuario.CustoEfetivoMensal = simulaUser.CustoEfetivoMensal;

            _context.SaveChanges();
        }
    }
}
