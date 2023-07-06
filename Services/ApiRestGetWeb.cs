using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_esqueletonMVC.ViewModels;
using maui_esqueletonMVC.Models;
using System.Xml;

namespace maui_esqueletonMVC.Services
{
    /// <summary>
    /// No instanciar esta clase. Usar sus clases hijas clienteWebXML o clienteWebJSON
    /// </summary>
    internal abstract class ApiRestGetWeb
    {
        protected Uri miURL;
        protected HttpClient _httpClient;
        
        protected ApiRestGetWeb() {
            _httpClient = new HttpClient();
        }

    }
    /// <summary>
    /// Conector API REST para consumir un fichero XML
    /// </summary>
    internal class ClienteWebXML : ApiRestGetWeb
    {
        public ClienteWebXML(string urlOrigenDatos) : base()
        {
            this.miURL = new(urlOrigenDatos);
        }
        public async Task<XmlDocument> GetDatosXML()
        {
            System.Xml.XmlDocument rssDoc = new();
            try
            {
                // Llamamos a la URL de noticias y nos devuelve un fichero XML que guardamos en
                // una variable de tipo Stream
                Stream myStream = Stream.Null;
                HttpResponseMessage respuesta = await this._httpClient.GetAsync(this.miURL);
                if (respuesta.IsSuccessStatusCode)
                {
                    myStream = respuesta.Content.ReadAsStream();
                }
                
                //Creamos un documento XML vacío y lo llenamos con la variable de tipo Stream anterior               
                rssDoc.Load(myStream);

            }
            catch (Exception ex)
            {
                rssDoc.Load(ex.Message);
            }
            return rssDoc;

        }
    }
    /// <summary>
    /// Conector a API REST para consumir un fichero JSON
    /// </summary>
    internal class ClienteWebJSON : ApiRestGetWeb
    {
        public ClienteWebJSON(string urlOrigenDatos)
        {
            this.miURL = new(urlOrigenDatos);
        }
        public async Task<String> ObtenerDatosJSON()
        {
            string JsonDevuelto = "";
            try
            {
                HttpResponseMessage respuesta = await this._httpClient.GetAsync(this.miURL);
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenido = await respuesta.Content.ReadAsStringAsync();
                    JsonDevuelto = contenido;
                }
            }
            catch (Exception excep)
            {
                JsonDevuelto = excep.Message;
                Console.WriteLine(JsonDevuelto);
            }
            return JsonDevuelto;
        }
    }
}
