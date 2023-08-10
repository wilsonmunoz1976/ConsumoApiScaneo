

namespace ConsumoApiScaneo.Estructuras
{
    public class Inventario
    {
        public RespuestaEjecucion? Respuesta { get; set; }
        public List<InventarioDet>? Detalle { get; set; }
    }
}