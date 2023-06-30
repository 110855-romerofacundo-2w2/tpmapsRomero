using APITpHereMap.Resultados.Usuarios;
using System.Net;

namespace APITpHereMap.Resultados;

    public class ResultadoBase
    {
        public bool Ok { get; set; } = true;
        public string MensajeError { get; set; } = "";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    //public List<MarcadorResultado> ListaMarcadores { get; set; }; //= new List<MarcadorResultado>();

    public void SetMensajeError(string mensajeError, HttpStatusCode statusCode)
        {
            Ok = false;
            MensajeError = mensajeError;
            StatusCode = statusCode;
        }
    }

