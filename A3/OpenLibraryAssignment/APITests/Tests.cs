using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenLibraryAPITests.API.Request;
using System;
using System.Collections;
using System.Threading.Tasks;
using static OpenLibraryAPITests.API.Response.ResponseObject;

namespace OpenLibraryAPITests.APITests
{
    public class Tests
    {
        [Category("Test")]
        [Test]
        public async Task TC01_ApiIsUpAndRunning()
        {
            Requests api = new Requests();

            var response = await api.SanityTest();
        }

        [Category("Test")]
        [Test]
        public async Task TC02_GetNumberOfBooks()
        {
            string searchString = "Goodnight Moon";

            Requests api = new Requests();

            var response = await api.GetResponseFromAPI(searchString);
            Console.WriteLine(response.numFound);
        }

        [Category("Test")]
        [Test]
        public async Task TC03_GetListOfBooksSince2000()
        {
            string searchString = "Goodnight Moon";

            Requests api = new Requests();

            var response = await api.GetResponseFromAPI(searchString);
            Console.WriteLine(response);
            Doc[] docs = response.docs;
            var keyList = new ArrayList();

            foreach (Doc d in docs){
                int first_publish_year = d.first_publish_year;
                if (first_publish_year >= 2000)
                {
                    keyList.Add(d.key);
                }

            }
            Console.WriteLine("Total Keys found : " + keyList.Count);

            foreach (var key in keyList)
            {
                Console.WriteLine(key);
            }

        }

        [Category("Test")]
        [Test]
        public async Task TC04_MatchResponse()
        {
            string expectedFilePath = @"D:\Work\Visual Studio Projects\OpenLibraryAssignment\Resources\expectResponse.json";
            string notExpectedFilePath = @"D:\Work\Visual Studio Projects\OpenLibraryAssignment\Resources\notExpectedResponse.json";

            string searchString = "Goodnight+Moon+123+Lap+Edition";

            Requests api = new Requests();

            var response = api.GetResponseFromAPIInString(searchString);
            JToken actualJSON = JToken.Parse(response);
            JToken expectedJSON = JToken.Parse(Requests.readJson(expectedFilePath));
            JToken notExpectedJSON = JToken.Parse(Requests.readJson(notExpectedFilePath));

            actualJSON.Should().BeEquivalentTo(expectedJSON);
            //actualJSON.Should().BeEquivalentTo(notExpectedJSON);

        }



    }
}
