using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using jira_api_serv.Models;

namespace jira_api_serv.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SwaggerController : Controller
    {
        /// <summary>
        /// This is the API which will return a list of worklog
        /// </summary>
        /// <returns></returns>
        // GET: api/
        [HttpGet]
        public JsonResult GetWorklog([FromHeader]string email,[FromHeader] string password )
        {
            var client = new RestClient("https://rita-api.atlassian.net/rest/api/3/issue/MT-3/worklog");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{email}:{password}")));
            request.AddHeader("Cookie", "atlassian.xsrf.token=db078c5a-73ad-466c-bd83-c4cf6a9a7fc5_3cdec18591ce625810ee5dfd12f8d9a020b5a09a_lin");
            IRestResponse response = client.Execute(request);
            return Json(response.Content);
        }
        [HttpPost]
        public JsonResult AddWorklog([FromHeader] string email, [FromHeader] string password, string timeSpent, string comment)
        {
            var client = new RestClient("https://rita-api.atlassian.net/rest/api/3/issue/MT-3/worklog/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{email}:{password}")));
            request.AddHeader("Cookie", "atlassian.xsrf.token=db078c5a-73ad-466c-bd83-c4cf6a9a7fc5_358f93b579b156121f5bc23015e2a23fa3fc9ade_lin");
            JSON qury = new JSON
            {
                timeSpent = "1d",
                comment = new Comment
                {
                    type = "doc",
                    version = 1,
                    content = new List<Content>() {
                        new Content {
                            type= "paragraph",
                            content = new List<ContentT>() {
                                new ContentT {
                                    text = comment,
                                    type= "text" } } }  }
                }
            };
            var body = JsonConvert.SerializeObject(qury);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return Json(response.Content);
        }
        [HttpDelete("{idworklog}")]
        public JsonResult DeleteLoan([FromHeader] string email, [FromHeader] string password,int idworklog)
        {
            var client = new RestClient($"https://rita-api.atlassian.net/rest/api/3/issue/MT-3/worklog/{idworklog}");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{email}:{password}")));
            IRestResponse response = client.Execute(request);
            return Json(response.Content);
        }
    }
}
