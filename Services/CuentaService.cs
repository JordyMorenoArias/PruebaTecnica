using Microsoft.AspNetCore.Http.HttpResults;
using PruebaTecnica.Models.Entities;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Services
{
    public class CuentaService
    {
        private readonly CuentaRepository _cuentaRepository;

        public CuentaService(CuentaRepository cuentaRepository)
        {
            this._cuentaRepository = cuentaRepository;
        }

        public Cuenta Depositar(int cuentaId, decimal monto)
        {
            var cuenta = _cuentaRepository.ObtenerPorId(cuentaId);

            if (cuenta == null)
            {
                throw new KeyNotFoundException("Cuenta no encontrada");
            }

            return _cuentaRepository.Depositar(cuenta, monto);
        }

        public Cuenta Retirar(int cuentaId, decimal monto)
        {
            var cuenta = _cuentaRepository.ObtenerPorId(cuentaId);

            if (cuenta == null)
            {
                throw new KeyNotFoundException("Cuenta no encontrada");
            }

            if (cuenta.saldoInicial < monto)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
            
            return _cuentaRepository.retirar(cuenta, monto);
        }

        public ICollection<Movimientos> ObtenerHistorial(int cuentaId)
        {
            var cuenta = _cuentaRepository.ObtenerPorId(cuentaId);

            if (cuenta == null)
            {
                throw new KeyNotFoundException("Cuenta no encontrada");
            }

            return _cuentaRepository.ObtenerHistorial(cuentaId);
        }
    }
}
