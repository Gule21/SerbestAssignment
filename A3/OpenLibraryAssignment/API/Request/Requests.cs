using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static OpenLibraryAPITests.API.Response.ResponseObject;

namespace OpenLibraryAPITests.API.Request
{
    class Requests
    {
        private HttpClient httpClient = new HttpClient();

        private string URI = "https://openlibrary.org/search.json?q=";

        private string query = "Goodnight+Moon+123+lap";

        public int RootObject { get; private set; }

        public async Task<string> SanityTest()
        {
            var Builder = new System.UriBuilder($"{URI}" + query);

            var response = await httpClient.GetAsync(Builder.Uri);

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
            return content;

        }

        public async Task<Rootobject> GetResponseFromAPI(string searchString)
        {
            string html;
            string url = URI + searchString;
            Console.WriteLine(url);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<Rootobject>(html);

            return apiResponse;
        }

        public string GetResponseFromAPIInString(string searchString)
        {
            string html;
            string url = URI + searchString;
            Console.WriteLine(url);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            Stream stream = webResponse.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }   

            return html;
        }

        public static string readJson(string fileName)
        {
            string json;
            using (StreamReader r = new StreamReader(fileName))
            {
                json = r.ReadToEnd();                
            }

            return json;
        }
    }
}
