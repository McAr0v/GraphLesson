﻿using StoreMarketApp.Models;

namespace StoreMarketApp.Contracts.Requests
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; } = decimal.Zero;

        /*public Product GetEntity() 
        {
            return new Product { Name = Name, Description = Description, Price = Price, CategoryId = CategoryId };
        }*/

    }


}
