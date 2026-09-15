using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    public class CuentaController : Controller
    {
        private readonly CuentaService _cuentaService;

        public CuentaController(CuentaService cuentaService)
        {
            this._cuentaService = cuentaService;
        }

        [HttpPost("api/cuenta/depositar")]
        public IActionResult Depositar(int usuarioId, decimal monto)
        {
            try
            {
                var cuenta = _cuentaService.Depositar(usuarioId, monto);
                return Ok(cuenta);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("api/cuenta/retirar")]
        public IActionResult Retirar(int usuarioId, decimal monto)
        {
            try
            {
                var cuenta = _cuentaService.Retirar(usuarioId, monto);
                return Ok(cuenta);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("api/cuenta/historial")]
        public IActionResult ObtenerHistorial(int usuarioId)
        {
            try
            {
                var historial = _cuentaService.ObtenerHistorial(usuarioId);
                return Ok(historial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
