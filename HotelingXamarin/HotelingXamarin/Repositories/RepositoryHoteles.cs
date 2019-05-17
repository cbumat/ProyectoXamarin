using HotelingXamarin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelingXamarin.Repositories
{
    public class RepositoryHoteles
    {
        String urlapi;
        public RepositoryHoteles() { this.urlapi = "https://apihotelescbm.azurewebsites.net/"; }

        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<String> GetToken(String email, String password)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "login";
                client.BaseAddress = new Uri(this.urlapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                FormUrlEncodedContent content =
                    new FormUrlEncodedContent(new[]
                    {
new KeyValuePair<string, string>("grant_type", "password")
,new KeyValuePair<string, string>("username", email)
,new KeyValuePair<string, string>("password", password)
                    });
                HttpResponseMessage response = await
client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido = await
response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(contenido);
                    String token = json.GetValue("access_token").ToString();
                    return token;
                }
                else
                {
                    return null;
                }

            }
        }

        private async Task<T> CallApi<T>(String peticion, String token)  {
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(this.urlapi);
                client.DefaultRequestHeaders.Accept.Clear();
                MediaTypeWithQualityHeaderValue headerjson = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                if (token != null) {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer "
                        + token);
                }
                HttpResponseMessage response = await client.GetAsync(peticion);
                if (response.IsSuccessStatusCode) {
                    String content = await response.Content.ReadAsStringAsync();
                    //DESERIALIZAR LOS DATOS CON JSONCONVERT
                    T datos = JsonConvert.DeserializeObject<T>(content);
                    //T datos = await response.Content.ReadAsStringAsync();
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }

        }

        public async Task<Usuario> PerfilUsuario(String token) {
            Usuario usuario = await CallApi<Usuario>("api/PerfilUsuario", token);
            return usuario;
        }

        public async Task InsertarUsuario(Usuario usuario)
        {
            String jsonusuario = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            byte[] bufferapuesta = Encoding.UTF8.GetBytes(jsonusuario);
            ByteArrayContent content = new ByteArrayContent(bufferapuesta);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            String peticion = "api/InsertarUsuario";
            Uri uri = new Uri(this.urlapi + peticion);
            HttpClient client = this.GetHttpClient();
            HttpResponseMessage response = await client.PostAsync(uri, content);
        }
    }
}
