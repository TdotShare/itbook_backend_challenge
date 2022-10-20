using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace itbook_test
{
    [TestClass]
    public class TestApiAuthen
    {
        [TestMethod]
        public async Task Test_Login_User_Success()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new
            {
                username = "jirayu.co",
                passowrd = "123"
            };


            var request = await httpClient.PostAsync("/login" , new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();


            Console.WriteLine(data);

            //Assert.Equals(HttpStatusCode.OK, request.StatusCode);

        }
    }
}