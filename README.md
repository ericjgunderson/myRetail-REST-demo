# myRetail-REST-demo
Demo app showcasing REST microservice architecture

**Objective:**

Demonstrate the creation of a restful products API (for a simulated retail company) which will aggregate product data from multiple sources and return it as JSON to the caller. The goal is to create a RESTful service that can retrieve product and price details by ID. 

**Requirements:**
1. Create a logical URL structure for HTTP calls.
2. One HTTP GET request at URI (Uniform Resource Identifier) "/products/{id}" and delivers product data as a JSON response (where {id} will be assumed to be a number)
3. Performs an HTTP GET request inside the HTTP GET request defined in 2. (referencing URI "/products/{id}") in order to retrieve the product name from an external API
4. Reads the pricing information from a NoSQL data store and combines it with the product id and name from the HTTP requests in requirement 2 and 3; returns price in response of requirment 2.
5. Accepts an HTTP PUT request at the same URI path from requirement 2, containing a JSON request body similar to the GET response, and updates the product’s price in the data store.
