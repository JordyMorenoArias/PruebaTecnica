using PruebaTecnica.Models.Enums;

namespace PruebaTecnica.Models.Entities
{
    public class Movimientos
    {
        public int Id { get; set; }

        public int cuentaId { get; set; }

        public decimal monto { get; set; }

        public TipoDeMovimiento tipoDeMovimiento { get; set; }

        public DateTime fecha { get; set; } = DateTime.Now;
    }
}
