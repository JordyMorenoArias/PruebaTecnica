using PruebaTecnica.Models.Entities;
using PruebaTecnica.Models.Enums;

namespace PruebaTecnica.Repositories
{
    public class CuentaRepository
    {
        private List<Cuenta> cuentas = new List<Cuenta>();

        public CuentaRepository()
        {
            cuentas.Add(new Cuenta { Id = 1, numeroCuenta = "123456789", nombreSocio = "Juan Perez", saldoInicial = 1000 });
        }

        public Cuenta? ObtenerPorId(int cuentaId)
        {
            return cuentas.FirstOrDefault(c => c.Id == cuentaId);
        }

        public Cuenta Depositar(Cuenta cuenta, decimal monto)
        {
            cuenta.movimientos.Add(new Movimientos { Id = 1, cuentaId = cuenta.Id, fecha = DateTime.Now, tipoDeMovimiento = TipoDeMovimiento.deposito, monto = monto });
            cuenta.saldoInicial += monto;
            cuentas[cuentas.IndexOf(cuenta)] = cuenta;
            return cuenta;
        }

        public Cuenta retirar(Cuenta cuenta, decimal monto)
        {
            cuenta.movimientos.Add(new Movimientos { Id = 2, cuentaId = cuenta.Id, fecha = DateTime.Now, tipoDeMovimiento = TipoDeMovimiento.retiro, monto = monto });
            cuenta.saldoInicial -= monto;
            cuentas[cuentas.IndexOf(cuenta)] = cuenta;
            return cuenta;
        }

        public ICollection<Movimientos> ObtenerHistorial(int cuentaId){
            Cuenta cuenta = ObtenerPorId(cuentaId)!;
            return cuenta?.movimientos ?? new List<Movimientos>();
        }
    }
}
