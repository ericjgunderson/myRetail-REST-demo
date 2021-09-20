using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Product.Models
{
    
    public class HTTPCaller
    {
        public HttpClient HTTPCallerClient;
        public HTTPCaller() { 
        
        HTTPCallerClient = new HttpClient();
        }

        public async Task<string> HttpCallerGetAsync(string url)
        {
            try
            {
                HttpResponseMessage r = await HTTPCallerClient.GetAsync(url);
                r.EnsureSuccessStatusCode();
                return await r.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                return "Exception Encountered with Message:" + ex.Message;
            }
        }
    }
}
