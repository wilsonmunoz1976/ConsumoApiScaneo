using System.Text.Json.Serialization;

namespace ConsumoApiScaneo.Estructuras
{
    public class LoginDato
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Username { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
    }
}
