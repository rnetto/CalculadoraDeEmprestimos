using CalculadoraDeEmprestimos.Data;
using CalculadoraDeEmprestimos.Models;
using CalculadoraDeEmprestimos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(_calcEmprestimoService.GetSaldos(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        public IActionResult CalculaValor(int qtdMes, decimal valorPretendido, decimal taxaMensal)
        {            
            return Json(_calcEmprestimoService.GetSimulacaoCalc(qtdMes, valorPretendido, taxaMensal));
        }

        public IActionResult SalvarSimulacao(SimulacaoUsuario simulacaoUsuario)
        {
            try
            {
                simulacaoUsuario.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _calcEmprestimoService.PostSimulacaoCalc(simulacaoUsuario);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
