using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

public static class Function1
{
    [Function("Function1")]
    public static async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("Function1");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        // Call the method to perform the login
        var loginResponse = await PerformLoginAsync();

        // Return the response from the login attempt
        var response = req.CreateResponse(loginResponse.StatusCode);
        await response.WriteStringAsync(await loginResponse.Content.ReadAsStringAsync());

        return response;
    }

    private static async Task<HttpResponseMessage> PerformLoginAsync()
    {
        using (var client = new HttpClient())
        {
            // Set the base address to the target URL
            client.BaseAddress = new Uri("https://achieverooms.skedda.com");

            // Create the request message
            var request = new HttpRequestMessage(HttpMethod.Get, "/");

         
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("Sec-Ch-Ua", "\"Google Chrome\";v=\"131\", \"Chromium\";v=\"131\", \"Not_A Brand\";v=\"24\"");
            request.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
            request.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
            request.Headers.Add("Sec-Fetch-Dest", "document");
            request.Headers.Add("Sec-Fetch-Mode", "navigate");
            request.Headers.Add("Sec-Fetch-Site", "none");
            request.Headers.Add("Sec-Fetch-User", "?1");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");
            request.Headers.Add("Referer", "https://achieverooms.skedda.com");

         
            request.Headers.Add("Cookie", "intercom-device-id-7bfdd68951cfb3532964743aa3f1595669f10598=d2b18d90-29d9-47ec-ad58-11f42e253ca9");
            request.Headers.Add("Cookie", "intercom-id-7bfdd68951cfb3532964743aa3f1595669f10598=a9a8e306-17f0-4916-b9e4-8060dae1dad5");
            request.Headers.Add("Cookie", "_vwo_uuid_v2=DD6C346A21E98479EAF8BFABD7B1FA872|189fdb01b652c2b3a0ddde03d3114b25");
            request.Headers.Add("Cookie", "_vwo_ds=3%241733337274%3A85.54261749%3A%3A");
            request.Headers.Add("Cookie", "_ga=GA1.1.1978794779.1733330261");
            request.Headers.Add("Cookie", "_ga_L1H7EDJ42T=GS1.1.1735570163.19.0.1735570167.0.0.0");
            request.Headers.Add("Cookie", "X-Skedda-RequestVerificationCookie=CfDJ8EEocIaYeINNkvfZHhJ8P5opcYVK5vjeOQw8fSkqQ8qHoy97-Sjqq7s-ePwG5n9Dz5TbFSqRKG7IlQv_lx-Cl9chQbHOOBytRQF22-p8rmSLXnLO2RQI-BOeb8CdL5v7ni0daFvXNjIwe7e72rWTBLc");
            request.Headers.Add("Cookie", "_gcl_gs=2.1.k1$i1735829969$u137064242");

            try
            {
                // Send the request and return the response
                var response = await client.SendAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }

}




}
