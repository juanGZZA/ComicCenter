using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int TotalArticulo { get; set; }
        public decimal MontoTotal { get; set; }
        public int IdTransaccion { get; set; }

        public List<DetalleVenta> oDetalleVenta { get; set; }

}
}
