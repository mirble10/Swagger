using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    public class Auth
    {
        public string[] otvet { get; set; }
        private string Token {  get; set; }

        public void Auth1() 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.59.39:12345/api/Auth/GetToken");
            var content = new StringContent("{\r\n  \"name\": \"t\",\r\n  \"password\": \"123\",\r\n  \"login\": \"admin\"\r\n}", null, "application/json");
            request.Content = content;
            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            string token = response.Content.ReadAsStringAsync().Result;
            Token = token;
            Examination($"http://192.168.59.39:12345/api/Groups?token={Token}");
        }
        private void Examination(string token)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, token);
            var response = client.SendAsync(request).Result;
            


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                
                Auth2($"http://192.168.59.39:12345/api/Groups?token={Token}");

            }
            else
            {
                Auth1();
            }
         
        }
        private void Auth2(string token)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, token);
            var response =  client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            var a = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);
            otvet = a;
        
        }

    }
}
