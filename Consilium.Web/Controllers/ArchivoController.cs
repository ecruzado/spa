using Consilium.Entity;
using Consilium.Logica;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace Consilium.Web.Controllers
{
    public class ArchivoController : ApiController
    {
        [HttpPost]
        public Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            HttpRequestHeaders headerRequest = Request.Headers;
            var listaClaseId = new List<string>(headerRequest.GetValues("claseId"));
            var claseId = Convert.ToInt32(listaClaseId[0]);

            string root = HttpContext.Current.Server.MapPath("~/App_Data/files");
            var provider = new MultipartFormDataStreamProvider(root);

            // Read the form data and return an async task.
            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }

                    // This illustrates how to get the file names.
                    String fileName = string.Empty;
                    Guid archivo ;
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        fileName = file.Headers.ContentDisposition.FileName;
                        archivo = Guid.NewGuid();

                        if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                        {
                            fileName = fileName.Trim('"');
                        }
                        if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                        {
                            fileName = Path.GetFileName(fileName);
                        }
                        File.Move(file.LocalFileName, Path.Combine(root, archivo.ToString()));
                        ClaseLogica.Instancia.CrearClaseArchivo(new ClaseArchivo {
                            ClaseId = claseId,
                            Nombre = fileName,
                            Archivo = archivo
                        });
                    }

                    var resultado = Request.CreateResponse(HttpStatusCode.OK);
                    
                    return resultado;
                });

            return task;
        }

        public HttpResponseMessage Get(int id)
        {
            var archivo = ClaseLogica.Instancia.GetClaseArchivoById(id);
            string root = HttpContext.Current.Server.MapPath("~/App_Data/files");
            string path = Path.Combine(root, archivo.Archivo.ToString());

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment"){FileName = archivo.Nombre};
            return result;
        }


    }
}
