using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers; 

public static async Task Run(string myIoTHubMessage, ILogger log)
{
    string URL = "<url to call>";
    string urlParameters = $"<url parameter string>";

    log.LogInformation($"C# IoT Hub trigger function processed a message: {myIoTHubMessage}");
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(URL);
    // Add an Accept header for JSON format.
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    // Add basic authentication
    var byteArray = Encoding.ASCII.GetBytes("user:password");
    client.DefaultRequestHeaders.Authorization 
                   = new AuthenticationHeaderValue("basic",Convert.ToBase64String(byteArray));
    // send the iot hub message content as payload
    var content = new StringContent(myIoTHubMessage.ToString(), Encoding.UTF8, "application/json");
    // List data response.
    HttpResponseMessage response = client.PostAsync(urlParameters,content).Result;  

    if (response.IsSuccessStatusCode)
       {
          string responsetext=await response.Content.ReadAsStringAsync();  
          log.LogInformation("{0}: {1} {2}", (int)response.StatusCode, Convert.ToString(response),responsetext);
       }
    else
       {
          log.LogInformation("{0} ({1}) {2}", (int)response.StatusCode, response.ReasonPhrase,Convert.ToString(response));
        }

    client.Dispose(); 
}
