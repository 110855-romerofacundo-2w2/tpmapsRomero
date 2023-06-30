namespace APITpHereMap.Resultados.Usuarios
{
    public class UsuarioResultado    
    {
        public Guid IdUsuario { get; set; }
        public string Token { get; set; }
        public string EmailUsuario { get; set; } = string.Empty;
        public string? UrlImagen { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public string? RolName { get; set; }
        public string Error { get; set; } = string.Empty;
        public bool Ok { get; set; }
        public string MensajeInfo { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}
