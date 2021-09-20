using Microsoft.AspNetCore.Mvc;
using myRetailAPI.Models;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRetailAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet()]
        [Route("api/[controller]/{id}")]
        public async Task<Products> GetProduct(long id, string prodDetailsField="title", long storeID = 1)
        {
            HTTPCaller call = new HTTPCaller();
            JSONParse jParse = new JSONParse();

            //call product_details API
            string productDetailResponse = await call.HttpCallerGetAsync("https://redsky.target.com/v3/pdp/tcin/13860428?excludes=taxonomy,price,promotion,bulk_ship,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics&key=candidate");
            
            //parse json string for field that is equivalent to productname; default is title
            //dynamic json parsing used
            Dictionary<string, string> allStringValuePairs = new Dictionary<string, string>();
            allStringValuePairs = jParse.deserializeJSONSelect(productDetailResponse, allStringValuePairs);
            string foundValueInProductDetailJSON = "";
            try
            {
                foundValueInProductDetailJSON = allStringValuePairs.Where(found => found.Key.StartsWith(prodDetailsField)).Select(found => found.Value).First().ToString();
            }
            catch
            {

            }
            

            //call product_price liteDB API
            string productPriceResponse = await call.HttpCallerGetAsync("https://localhost:44352/api/ProductPrice/"+id+"/"+storeID);

            Dictionary<string, string> ValuePairsPricing = new Dictionary<string, string>();
            ValuePairsPricing = jParse.deserializeJSONSelect(productPriceResponse, ValuePairsPricing);
            string retPrice = "";
            try
            {
                retPrice = ValuePairsPricing.Where(found => found.Key.StartsWith("priceVal")).Select(found => found.Value).First().ToString();
            }
            catch(Exception ex)
            {

            }
            
           


            return new Products() { ItemName = foundValueInProductDetailJSON, Price = retPrice, ProdID = id };

        }
    }
}
