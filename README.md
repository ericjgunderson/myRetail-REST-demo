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

Looking through the requirements, it can be interpreted that three separate services exist to manage information if we are to follow microservice architecture: products (requirement 2), product_detail (Requirement 3), and product_pricing (Requirement 4). The products service is the only service to communicate with client apps, while the other two services are to be considered "backend" or "company use" only. Also, an assumption will be made that suggests that all three services sit under the same domain and that Cross-Origin Resource Sharing (CORS) is not an issue between the three services. For this design, product_detail will be a simulated service with a JSON format already in place and no coding being done to alter response structure. Based on requirement 6 and the initial objective, an API gateway will be used to simplify routing to the products API and to handle possible future scaling/throttling.

![Microservice API Design](https://user-images.githubusercontent.com/53889382/133884427-966f29c9-cd05-4559-9ea0-66cbcb4c7bb8.PNG)
