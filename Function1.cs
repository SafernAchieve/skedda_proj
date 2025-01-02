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
        // Initialize a CookieContainer for managing cookies
        var cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler
        {
            CookieContainer = cookieContainer
        };

        using (var client = new HttpClient(handler))
        {
            // Set the base address
            client.BaseAddress = new Uri("https://achieverooms.skedda.com");

            // Set default headers (applies to all requests made by this client)
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/avif"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/apng"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");

            // Add cookies
            cookieContainer.Add(new Uri("https://achieverooms.skedda.com"), new Cookie("intercom-device-id-7bfdd68951cfb3532964743aa3f1595669f10598", "d2b18d90-29d9-47ec-ad58-11f42e253ca9"));
            cookieContainer.Add(new Uri("https://achieverooms.skedda.com"), new Cookie("intercom-id-7bfdd68951cfb3532964743aa3f1595669f10598", "a9a8e306-17f0-4916-b9e4-8060dae1dad5"));
            cookieContainer.Add(new Uri("https://achieverooms.skedda.com"), new Cookie("_vwo_uuid_v2", "DD6C346A21E98479EAF8BFABD7B1FA872|189fdb01b652c2b3a0ddde03d3114b25"));
            // Add other cookies similarly...

            // Create the request
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Referrer = new Uri("https://achieverooms.skedda.com");

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
