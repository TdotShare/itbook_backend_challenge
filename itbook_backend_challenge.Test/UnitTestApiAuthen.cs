using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace itbook_backend_challenge.Test
{
    [TestClass]
    public class UnitTestApiAuthen
    {
        [TestMethod]
        public async Task Test_Login_User_Success()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new
            {
                username = "jirayu.co",
                password = "123"
            };


            var request = await httpClient.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.OK, request.StatusCode);

        }


        [TestMethod]
        public async Task Test_Login_User_Fail()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new
            {
                username = "jirayu.co",
                password = "1234"
            };


            var request = await httpClient.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.BadRequest, request.StatusCode);

        }

        [TestMethod]
        public async Task Test_Register_User_Success()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new
            {
                username = $"jirayu.test.{DateTime.Now.ToString("mmss")}",
                password = "1234",
                fullname = $"jirayu.test.{DateTime.Now.ToString("mmss")}",
            };


            var request = await httpClient.PostAsync("/register", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.OK, request.StatusCode);

        }

        [TestMethod]
        public async Task Test_Register_User_ErrorInput()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new
            {
                username = $"jirayu.test.{DateTime.Now.ToString("mmss")}",
                password = "1234",
            };


            var request = await httpClient.PostAsync("/register", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.BadRequest, request.StatusCode);

        }
    }
}