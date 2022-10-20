using itbook_backend_challenge.Config;
using itbook_backend_challenge.Mapdata.Responses;
using itbook_backend_challenge.Mapdata.Formactions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace itbook_backend_challenge.Test
{
    [TestClass]
    public class UnitTetsApiUser
    {

        public async Task<ProfileData> Get_Token_User()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var data = new LoginUser
            {
                username = "jirayu.co",
                password = "123"
            };

            var request = await httpClient.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var profile_data = await request.Content.ReadFromJsonAsync<ProfileData>();

            return profile_data;
        }

        [TestMethod]
        public async Task Test_Get_User()
        {

            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var profile_data = await Get_Token_User();
            var token_data = profile_data.token;

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token_data);
            var request = await httpClient.GetAsync("/user");
            var resp = await request.Content.ReadAsStringAsync();

            Console.WriteLine(resp);

            Assert.AreEqual(HttpStatusCode.OK, request.StatusCode);
        }

        [TestMethod]
        public async Task Test_Get_LikeBook_FoundData()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();

            var profile_data = await Get_Token_User();
            var token_data = profile_data.token;

            var data  = new LikeBookUser
            {
                book_id = 9780596100896,
                user_id = profile_data.user.user_id
            };

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token_data);
            var request = await httpClient.PostAsync("/user/like" , new  StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();

            Console.WriteLine(resp);
            Assert.AreEqual(HttpStatusCode.OK, request.StatusCode);
        }

        [TestMethod]
        public async Task Test_Get_LikeBook_NotFoundData()
        {
            await using var application = new WebApplicationFactory<Program>();
            var httpClient = application.CreateDefaultClient();
            var profile_data = await Get_Token_User();
            var token_data = profile_data.token;
            var data = new LikeBookUser
            {
                book_id = 978059610089,
                user_id = profile_data.user.user_id
            };

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token_data);
            var request = await httpClient.PostAsync("/user/like", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            var resp = await request.Content.ReadAsStringAsync();

            Console.WriteLine(resp);

            Assert.AreEqual(HttpStatusCode.BadRequest, request.StatusCode);
        }

    }
}
