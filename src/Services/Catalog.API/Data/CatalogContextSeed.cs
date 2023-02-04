using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            if(!productCollection.Find(p => true).Any())
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name= "Refactoring",
                    Description="Refactoring, improving the design of existing code",
                    Summary="This eagerly awaited new edition has been fully updated to reflect crucial changes in the programing landscape.",
                    Category="Book",
                    ImageFile="Refactor.jpg",
                    Price= 78.01M
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "IPhone 14 Pro Max",
                    Description = "IPhone 14 Max",
                    Summary = "Designed for durability. With Ceramic Shield, tougher than any smartphone glass. Water resistance.1 Surgical-grade stainless steel. 6.1″ and 6.7″ display sizes.2 All in four Pro colors.",
                    Category = "Smart Phone",
                    ImageFile = "Iphone14M.jpg",
                    Price = 890.00M
                }
            };
        }
    }
}
