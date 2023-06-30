namespace APITpHereMap.Resultados.Usuarios
{
    public class Marcadores : ResultadoBase
    {
        public List<MarcadorResultado> ListadoMarcadores { get; set; } = new List<MarcadorResultado>();
    }

    public class MarcadorResultado 
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Info { get; set; }
    }
}
