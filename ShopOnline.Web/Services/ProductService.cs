﻿using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var response = await httpClient.GetAsync("api/Product");
                
                if (response.IsSuccessStatusCode)
                {

                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
