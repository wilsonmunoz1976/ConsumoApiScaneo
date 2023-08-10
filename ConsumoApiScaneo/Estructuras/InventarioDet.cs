namespace ConsumoApiScaneo.Estructuras
{
    public class InventarioDet
    {
        public string? Codigo { get; set; }
        public string? Articulo { get; set; }
        public decimal? Existencia { get; set; }
        public decimal? TomaFisica { get; set; }
        public decimal? Diferencia { get; set; }
    }
}