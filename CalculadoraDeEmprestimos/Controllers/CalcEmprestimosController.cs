using CalculadoraDeEmprestimos.Data;
using CalculadoraDeEmprestimos.Models;
using CalculadoraDeEmprestimos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CalculadoraDeEmprestimos.Controllers
{
    [Authorize]
    public class CalcEmprestimosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CalcEmprestimoService _calcEmprestimoService;

        public CalcEmprestimosController()
        {
            _context = new ApplicationDbContext();
            _calcEmprestimoService = new CalcEmprestimoService(_context);
        }
        public IActionResult Index()
        {
            try
            {
                return View(_calcEmprestimoService.GetSaldos(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult CalculaValor(int qtdMes, decimal valorPretendido, decimal taxaMensal)
        {
            try
            {
                var limites = _calcEmprestimoService.GetSaldos(User.FindFirstValue(ClaimTypes.NameIdentifier));
                string msg = "<h1><font color='red'> Valor requerido excede crédito aprovado!</font></h1>";

                if(valorPretendido < limites.ValorMinimo)
                    return Json("<h1><font color='green'> Valor requerido é menor que o mínimo estipulado.</font></h1>");

                if (qtdMes == 6 && valorPretendido > limites.LimiteCredTotal6)
                    return Json(msg);
                if (qtdMes == 12 && valorPretendido > limites.LimiteCredTotal12)
                    return Json(msg);
                if (qtdMes == 24 && valorPretendido > limites.LimiteCredTotal24)
                    return Json(msg);
                if (qtdMes == 36 && valorPretendido > limites.LimiteCredTotal36)
                    return Json(msg);

                return PartialView("_ResultadoSimulacaoPartial", _calcEmprestimoService.GetSimulacaoCalc(qtdMes, valorPretendido, taxaMensal/10));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult SalvarSimulacao(SimulacaoUsuario simulacaoUsuario)
        {
            try
            {
                simulacaoUsuario.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
               
                _calcEmprestimoService.PostSimulacaoCalc(simulacaoUsuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
