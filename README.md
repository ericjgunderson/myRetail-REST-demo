# myRetail-REST-demo
Demo app showcasing REST microservice architecture

## Overview

**Objective:**

Demonstrate the creation of a restful products API (for a simulated retail company with 200+ locations) which will aggregate product data from multiple sources and return it as JSON to the caller. The goal is to create a RESTful service that can retrieve product and price details by ID. 

**Requirements:**
1. Create a logical URL structure for HTTP calls.
2. Create one HTTP GET request at URI (Uniform Resource Identifier) "/products/{id}" which delivers product data as a JSON response (where {id} will be assumed to be a number)
3. Performs an HTTP GET request inside the HTTP GET request defined in requiremnet 2 that retrieves the product name from an API
4. Reads the pricing information from a NoSQL data store and combines it with the JSON product id and name from the HTTP requests in requirement 2 and 3 to return price in the response of requirment 2.
5. Accepts an HTTP PUT request at the same URI path from requirement 2, containing a JSON request body similar to the GET response, and updates the product’s price in the data store.
6. API can talk to multiple client devices; examples include: shared domain/network web apps,  mobile apps, etc. 

## Design

**General:**

Looking through the requirements, it can be interpreted that three separate services exist to manage information if we are to follow microservice architecture: products (requirement 2), product_detail (Requirement 3), and product_pricing (Requirement 4). The products service is the only service to communicate with client apps, while the other two services are to be considered "backend" or "company use" only. Also, an assumption will be made that suggests that all three services sit under the same domain and that Cross-Origin Resource Sharing (CORS) is not an issue between the three services. For this design, product_detail will be a simulated service with a JSON format already in place and no programming being done to alter formats of the response structure (as if to simulate an already in service API used by the retail business); JSON formatting may be done once the response from product_detail reaches the product API. Based on requirement 6 and the initial objective, an API gateway/proxy could be used to simplify routing to the products API and to handle possible future scaling/throttling.

![Microservice API Design](https://user-images.githubusercontent.com/53889382/133884427-966f29c9-cd05-4559-9ea0-66cbcb4c7bb8.PNG)

**Implementation:**

For the implementation of this design I have decided to use the C# programming language with the .NET 5.0 SDK(https://dotnet.microsoft.com/download/dotnet/5.0) and ASP.Net/web development package (https://docs.microsoft.com/en-us/visualstudio/install/workload-component-id-vs-professional?view=vs-2019#aspnet-and-web-development). The Integrated Development Environment (IDE) used to compile and locally run the code was Microsoft Visual Studio Community 2019 Version 16.11.3 running on a desktop machine with the operating system (x64) Windows 10 Pro OS build 19043.1237.


THE .NET 5.0 SDK is free, open source, and cross-platform. When utilizing the web development package and creating a WEB API solution, a Program.cs file and a Startup.cs file are created. The Program.cs file contains the Main(string[] args) function (which signifies the first element ran when starting the solution). Inside the Main() function, a call to the function CreateHostBuilder is performed such that a web host is being created with the parameters contained within the Startup.cs.


    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    
Beside the general C# setup files that handle the large task of starting the web service, creating a WEB API solution with .NET relies on the model/controller structure. A model class/.cs file contains the majority of the "backend" work (i.e. JSON manipulation, file reads/writes, etc.) while the controller may call functions contained within the model it also holds the important task of "controlling" where/how HTTP commands are accepted by way of tags above the functions it creates.

Example model:

    public class products
    {
        //This is a constructor for the products class
        //It has no parameters
        public products()
        {

        }


    }
    
Example controller:

    public class ProductsController : Controller
    {
        [HttpGet()]
        [Route("api/[controller]/{id}")]
        public void GetProduct(long id)
        {
            
        }
    }
