﻿using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase: ComponentBase
    {
        [Inject]
        public IProductService? ProductService { get; set; }
        public IEnumerable<ProductDto>? Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductService is not null) 
            {
                Products = await ProductService.GetItems();
            }
        }
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            var product = groupedProductDto.FirstOrDefault(pg => pg.CategoryId == groupedProductDto.Key);

            if (product is not null)
            {
                return product.CategoryName;
            }
            return string.Empty;
        }
    }
}
