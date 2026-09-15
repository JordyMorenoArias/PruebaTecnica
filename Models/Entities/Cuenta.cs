namespace PruebaTecnica.Models.Entities
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string numeroCuenta { get; set; }
        public string nombreSocio { get; set; }
        public decimal saldoInicial { get; set; }

        public ICollection<Movimientos> movimientos = new List<Movimientos>();
    }
}
