using proyecto.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace proyecto.Controllers
{
    [RoutePrefix("api/UploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        public Task<HttpResponseMessage> CargarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsupload upload = new clsupload();
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            upload.request = request;
            return upload.GrabarArchivo();
        }

    }
}
