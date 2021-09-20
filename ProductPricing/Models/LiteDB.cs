using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LiteDB;

namespace ProductPricing.Models
{
    public class LiteDB
    {
        public LiteDB()
        {

        }
        public void FillDB(string dbName, long storeID, long itemID, double price)
        {
            // Open database (or create if not exits)
            dbName=Regex.Replace(dbName, "[^a-zA-Z0-9]", String.Empty);
            using (var db = new LiteDatabase(dbName+".db"))
            {
                
                var prices = db.GetCollection<Price>("prices");
                // Create new price instance
                var p = new Price
                {
                    ItemID = itemID,
                    StoreID = storeID,
                    PriceVal = price
                };
                // Insert new user document (Id will be auto-incremented)
                prices.Insert(p);


                // Index document using a document property
                prices.EnsureIndex(x => new { x.ItemID, x.StoreID});
            }
        }

        public double GetPrice(string dbName, long itemId, long storeID)
        {
            double foundDBPrice = 0;

            try
            {

            
                using (var db = new LiteDatabase(dbName + ".db"))
                {
                    var prices = db.GetCollection<Price>("prices");

                     var foundRecord = prices.Find(x => x.ItemID == itemId && x.StoreID == storeID).FirstOrDefault();
                    foundDBPrice = foundRecord.PriceVal;
                }
            }
            catch(Exception ex)
            {
                //handle exception and allow 0 to be passed back knowing that 0 is an invalid price
            }

            return foundDBPrice;
        }
    }
}
